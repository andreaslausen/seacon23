using System;

namespace PizzaOnline.Core.Domain.Models
{
    public class Pizza
    {
        public Guid Id { get; private set; }

        public PizzaSize Size { get; }
        public decimal Price { get; }
        public PizzaSort Sort { get; }

        public Pizza(PizzaSize size, decimal price, PizzaSort sort)
        {
            Id = default;
            Size = size;
            Price = price;
            Sort = sort;
        }

        public Pizza(Guid id, PizzaSize size, decimal price, PizzaSort sort)
        {
            Id = id;
            Size = size;
            Price = price;
            Sort = sort;
        }

        public void SetId(Guid id)
        {
            if (Id == default)
            {
                throw new InvalidOperationException("Pizza hat schon eine Id");
            }

            Id = id;
        }
    }
}