using System;
using System.Collections.Generic;
using System.Linq;
using PizzaOnline.Core.Domain.Interfaces;
using PizzaOnline.Core.Domain.Models;

namespace PizzaOnline.Persistence.Memory
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly List<Pizza> _pizzas = new List<Pizza>();

        public PizzaRepository()
        {
            var tonno = new PizzaSort(new byte[0], 1, "Tonno");
            _pizzas.Add(new Pizza(Guid.NewGuid(), PizzaSize.Large, 16, tonno));
            _pizzas.Add(new Pizza(Guid.NewGuid(), PizzaSize.Medium, 14, tonno));
            _pizzas.Add(new Pizza(Guid.NewGuid(), PizzaSize.Small, 6.50m, tonno));

            var diavolo = new PizzaSort(new byte[0], 1, "Diavolo extra scharf!!");
            _pizzas.Add(new Pizza(Guid.NewGuid(), PizzaSize.Large, 15, diavolo));
            _pizzas.Add(new Pizza(Guid.NewGuid(), PizzaSize.Medium, 13.37m, diavolo));
            _pizzas.Add(new Pizza(Guid.NewGuid(), PizzaSize.Small, 5.50m, diavolo));
        }

        public IEnumerable<Pizza> GetPizzen()
        {
            return _pizzas;
        }

        public Pizza GetPizza(Guid pizzaId)
        {
            return _pizzas.SingleOrDefault(p => p.Id == pizzaId);
        }

        public void AddPizza(Pizza pizza)
        {
            _pizzas.Add(pizza);
        }
    }
}