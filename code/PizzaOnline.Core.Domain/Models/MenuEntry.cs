using System.Collections.Generic;
using System.Linq;

namespace PizzaOnline.Core.Domain.Models
{
    public class MenuEntry
    {
        public PizzaSort Sort { get; }
        public IEnumerable<Pizza> Pizzas { get; }

        public MenuEntry(IGrouping<PizzaSort, Pizza> pizzen)
        {
            Sort = pizzen.Key;
            Pizzas = pizzen;
        }
    }
}