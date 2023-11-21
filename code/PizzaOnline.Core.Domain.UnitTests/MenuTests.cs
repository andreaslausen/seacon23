using System;
using System.Collections.Generic;
using FluentAssertions;
using PizzaOnline.Core.Domain.Models;
using Xunit;

namespace PizzaOnline.Core.Domain.UnitTests
{
    public class MenuTests
    {
        [Fact]
        public void Create_ShouldNotBeNull()
        {
            var pizzaItems = new List<Pizza> {new Pizza(Guid.NewGuid(), PizzaSize.Large, 3.4m, new PizzaSort(null, 3, "fdksl,a"))};
            var menu = new Menu(pizzaItems);

            menu.Should().NotBe(null);
        }
    }
}