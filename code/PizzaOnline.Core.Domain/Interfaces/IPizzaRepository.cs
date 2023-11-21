using System;
using System.Collections.Generic;
using PizzaOnline.Core.Domain.Models;

namespace PizzaOnline.Core.Domain.Interfaces
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza> GetPizzen();
        Pizza GetPizza(Guid pizzaId);

        void AddPizza(Pizza pizza);
    }
}