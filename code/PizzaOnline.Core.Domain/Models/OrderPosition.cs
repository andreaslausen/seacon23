using System;

namespace PizzaOnline.Core.Domain.Models
{
    public class OrderPosition
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public int Count { get; }
        public Guid PizzaId { get; }
        public Pizza Pizza { get; }

        public OrderPosition(Order order, Pizza pizza, int count)
        {
            OrderId = order.Id;
            Pizza = pizza;
            PizzaId = pizza.Id;
            Count = count;
        }

        public OrderPosition(Guid orderId, Guid pizzaId, int count)
        {
            OrderId = orderId;
            PizzaId = pizzaId;
            Count = count;
        }

        public OrderPosition(Guid orderId, int count, Guid pizzaId, Pizza pizza)
        {
            OrderId = orderId;
            Count = count;
            PizzaId = pizzaId;
            Pizza = pizza;
        }

        public void SetId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("id must not be empty");
            }

            if (Id != Guid.Empty)
            {
                throw new InvalidOperationException("orderPosition already has an Id");
            }

            Id = id;
        }

        public decimal CalculateSum()
        {
            return Count * Pizza.Price;
        }

        public void SetOrderId(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}