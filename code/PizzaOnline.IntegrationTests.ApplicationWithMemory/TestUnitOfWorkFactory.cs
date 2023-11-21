using PizzaOnline.Core.Domain.Interfaces;
using PizzaOnline.Persistence.Memory;

namespace PizzaOnline.ApplicationWithMemory.IntegrationTests
{
    public class TestUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IPizzaRepository _pizzaRepository;

        public TestUnitOfWorkFactory(IPizzaRepository pizzaRepository, ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            _pizzaRepository = pizzaRepository;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return new InMemoryUnitOfWork(_pizzaRepository as PizzaRepository, _customerRepository as CustomerRepository, _orderRepository as OrderRepository);
        }
    }
}