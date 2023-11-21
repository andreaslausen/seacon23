using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using PizzaOnline.Core.Application.Contracts.Adapters;
using PizzaOnline.Core.Application.Contracts.Dtos;
using PizzaOnline.Core.Application.Mappers;
using PizzaOnline.Core.Application.Services;
using PizzaOnline.Core.Domain.Interfaces;
using PizzaOnline.Core.Domain.Models;
using Xunit;

namespace PizzaOnline.Core.Application.UnitTests
{
    public class OrderServiceTests
    {
        [Fact]
        public void Create_ShouldNotBeNull()
        {
            var unitOfWorkFactoryFake = new Mock<IUnitOfWorkFactory>();
            var orderMapper = new OrderMapper();
            var dateTimeProviderFake = new Mock<IDateTimeProvider>();
            var orderService = new OrderService(unitOfWorkFactoryFake.Object, orderMapper, dateTimeProviderFake.Object);

            orderService.Should().NotBe(null);
        }

        [Fact]
        public async Task CreateOrder_PizzaShouldNotBeNull()
        {
            var customerRepositoryFake = new Mock<ICustomerRepository>();
            var customer = new Customer(Guid.NewGuid(), 1, "fdjskla", "fdjhkas", "fdklsa");
            customerRepositoryFake.Setup(x => x.GetCustomer(It.IsAny<int>())).Returns(customer);
            var unitOfWorkFake = new Mock<IUnitOfWork>();
            unitOfWorkFake.SetupGet(x => x.CustomerRepository).Returns(customerRepositoryFake.Object);
            var pizzaRepositoryFake = new Mock<IPizzaRepository>();
            pizzaRepositoryFake.Setup(x => x.GetPizza(It.IsAny<Guid>())).Returns(new Pizza(Guid.Empty, PizzaSize.Large, 3.4m, new PizzaSort(null, 2, "fdjksl")));
            unitOfWorkFake.SetupGet(x => x.PizzaRepository).Returns(pizzaRepositoryFake.Object);
            var orderRepositoryFake = Mock.Of<IOrderRepository>();
            unitOfWorkFake.SetupGet(x => x.OrderRepository).Returns(orderRepositoryFake);
            var unitOfWorkFactoryFake = new Mock<IUnitOfWorkFactory>();
            unitOfWorkFactoryFake.Setup(x => x.CreateUnitOfWork()).Returns(unitOfWorkFake.Object);
            var orderMapper = new OrderMapper();
            var dateTimeProviderFake = new Mock<IDateTimeProvider>();
            var orderService = new OrderService(unitOfWorkFactoryFake.Object, orderMapper, dateTimeProviderFake.Object);

            var order = await orderService.CreateOrder(new NewOrderDto {CustomerNumber = 1, Positions = new[] {new OrderPositionDto {Count = 1, PizzaId = Guid.NewGuid()}}});

            order.Should().NotBe(null);
        }
    }
}