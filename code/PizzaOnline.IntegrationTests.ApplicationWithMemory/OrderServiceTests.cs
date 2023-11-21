using System;
using System.Threading.Tasks;
using FluentAssertions;
using PizzaOnline.Core.Application;
using PizzaOnline.Core.Application.Contracts.Dtos;
using PizzaOnline.Core.Application.Mappers;
using PizzaOnline.Core.Application.Services;
using PizzaOnline.Core.Domain.Models;
using PizzaOnline.Persistence.Memory;
using Xunit;

namespace PizzaOnline.ApplicationWithMemory.IntegrationTests
{
    public class OrderServiceTests
    {
        [Fact]
        public async Task CreateOrder_ShouldCreateANewOrder()
        {
            var pizzaRepository = new PizzaRepository();
            var customerRepository = new CustomerRepository();
            var orderRepository = new OrderRepository();

            var unitOfWorkFactory = new TestUnitOfWorkFactory(pizzaRepository, customerRepository, orderRepository);
            var orderMapper = new OrderMapper();
            var orderService = new OrderService(unitOfWorkFactory, orderMapper, new SystemDateTimeProvider());

            var pizzaId = Guid.Parse("D2250A09-4B0C-415B-9A46-46920CDE19D0");
            var pizzaSort = new PizzaSort(new byte[0], 23, "Tonno");
            var pizza = new Pizza(pizzaId, PizzaSize.Large, 9.80m, pizzaSort);
            pizzaRepository.AddPizza(pizza);

            const int customerNumber = 12345;
            var newOrder = new NewOrderDto
            {
                CustomerNumber = customerNumber,
                Positions = new[]
                {
                    new OrderPositionDto
                    {
                        Count = 2,
                        PizzaId = pizzaId
                    }
                }
            };
            var result = await orderService.CreateOrder(newOrder);

            result.Number.Should().BeGreaterThan(0);
            result.CustomerNumber.Should().Be(customerNumber);
            result.Sum.Should().Be(19.6m);

            await orderService.ConfirmOrder(result.Id);

            var x = await orderRepository.Get(result.Id);
            x.IsConfirmed.Should().BeTrue();
        }
    }
}