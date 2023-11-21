using FluentAssertions;
using Moq;
using PizzaOnline.Core.Application.Mappers;
using PizzaOnline.Core.Application.Services;
using PizzaOnline.Core.Domain.Interfaces;
using PizzaOnline.Persistence.Memory;
using Xunit;

namespace PizzaOnline.ApplicationWithMemory.IntegrationTests
{
    public class MenuServiceTests
    {
        [Fact]
        public void Test()
        {
            var pizzaRepository = new PizzaRepository();
            var unitOfWorkFactory = new TestUnitOfWorkFactory(pizzaRepository, new Mock<ICustomerRepository>().Object, new Mock<IOrderRepository>().Object);
            var mapper = new MenuMapper();
            var menuService = new MenuService(mapper, unitOfWorkFactory);

            var menu = menuService.GetMenu();
            menu.Eintraege.Length.Should().BeGreaterThan(0);
        }
    }
}