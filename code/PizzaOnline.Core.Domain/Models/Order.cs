using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaOnline.Core.Domain.Models
{
    public class Order
    {
        private readonly List<OrderPosition> _positionen = new List<OrderPosition>();

        public Guid Id { get; private set; }
        public int Number { get; }
        public IReadOnlyCollection<OrderPosition> Positionen => _positionen;
        public Guid CustomerId { get; }
        public Customer Customer { get; }
        public DateTime OrderTimeStamp { get; }
        public bool IsConfirmed { get; private set; }

        public Order(int number, Customer customer, DateTime orderTimeStamp)
        {
            Id = Guid.Empty;
            Number = number;
            Customer = customer;
            CustomerId = customer.Id;
            OrderTimeStamp = orderTimeStamp;
        }

        public Order(Guid id, int number, Guid customerId, DateTime orderTimeStamp, bool isConfirmed)
        {
            Id = id;
            Number = number;
            CustomerId = customerId;
            OrderTimeStamp = orderTimeStamp;
            IsConfirmed = isConfirmed;
        }

        public void SetId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("id must not be empty");
            }

            if (Id != Guid.Empty)
            {
                throw new InvalidOperationException("Order already has an Id");
            }

            Id = id;
        }

        public void AddPizza(Pizza pizza, int anzahl)
        {
            var position = new OrderPosition(this, pizza, anzahl);
            _positionen.Add(position);
        }

        public void RemovePizza(Pizza pizza)
        {
        }

        public void Confirm()
        {
            IsConfirmed = true;
        }

        public decimal CalculateSum()
        {
            return _positionen.Sum(p => p.CalculateSum());
        }
    }
}