using System.Collections.Generic;
using System.Linq;

namespace PizzaOnline.Core.Domain.Models
{
    public class Menu
    {
        public IReadOnlyCollection<Pizza> Pizzen { get; }

        public Menu(IReadOnlyCollection<Pizza> pizzen)
        {
            Pizzen = pizzen;
        }

        public IEnumerable<MenuEntry> GetMenuEntries()
        {
            return Pizzen.GroupBy(pizza => pizza.Sort).Select(pizzen => new MenuEntry(pizzen));
        }
    }
}