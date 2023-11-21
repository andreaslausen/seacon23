using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaOnline.Core.Domain.Interfaces;
using PizzaOnline.Core.Domain.Models;
using PizzaOnline.Persistence.Memory.Records;

namespace PizzaOnline.Persistence.Memory
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Action> _actions = new List<Action>();
        private readonly List<OrderPositionRecord> _orderPositions = new List<OrderPositionRecord>();
        private readonly List<OrderRecord> _orders = new List<OrderRecord>();

        public void Insert(Order order)
        {
            _actions.Add(() =>
            {
                var orderRecord = new OrderRecord
                {
                    CustomerId = order.Customer.Id,
                    Id = Guid.NewGuid(),
                    Number = order.Number,
                    IsConfirmed = order.IsConfirmed,
                    OrderTimeStamp = order.OrderTimeStamp
                };
                _orders.Add(orderRecord);
                order.SetId(orderRecord.Id);

                foreach (var orderPosition in order.Positionen)
                {
                    orderPosition.SetOrderId(order.Id);
                }
            });
        }

        public void Insert(IEnumerable<OrderPosition> orderPositions)
        {
            _actions.Add(() =>
            {
                foreach (var orderPosition in orderPositions)
                {
                    var orderPositionRecord = new OrderPositionRecord
                    {
                        Id = Guid.NewGuid(),
                        Count = orderPosition.Count,
                        OrderId = orderPosition.OrderId,
                        PizzaId = orderPosition.PizzaId
                    };
                    _orderPositions.Add(orderPositionRecord);
                    orderPosition.SetId(orderPositionRecord.Id);
                }
            });
        }

        public void Update(Order order)
        {
            _actions.Add(() =>
            {
                var orderRecord = _orders.SingleOrDefault(record => record.Id == order.Id);
                if (orderRecord == null)
                {
                    return;
                }

                orderRecord.CustomerId = order.CustomerId;
                orderRecord.Number = order.Number;
                orderRecord.IsConfirmed = order.IsConfirmed;
                orderRecord.OrderTimeStamp = order.OrderTimeStamp;
            });
        }

        public Task<Order> Get(Guid orderId)
        {
            var orderRecord = _orders.SingleOrDefault(o => o.Id == orderId);
            if (orderRecord == null)
            {
                return null;
            }

            return Task.FromResult(new Order(orderRecord.Id, orderRecord.Number, orderRecord.CustomerId, orderRecord.OrderTimeStamp, orderRecord.IsConfirmed));
        }

        internal Task ApplyChanges()
        {
            foreach (var action in _actions)
            {
                action();
            }

            _actions.Clear();

            return Task.CompletedTask;
        }
    }
}