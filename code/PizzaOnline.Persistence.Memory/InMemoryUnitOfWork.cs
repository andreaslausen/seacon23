using System.Threading.Tasks;
using PizzaOnline.Core.Domain.Interfaces;

namespace PizzaOnline.Persistence.Memory
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        private readonly CustomerRepository _customerRepository;
        private readonly OrderRepository _orderRepository;
        private readonly PizzaRepository _pizzaRepository;

        public IPizzaRepository PizzaRepository => _pizzaRepository;

        public ICustomerRepository CustomerRepository => _customerRepository;

        public IOrderRepository OrderRepository => _orderRepository;

        public InMemoryUnitOfWork(PizzaRepository pizzaRepository, CustomerRepository customerRepository, OrderRepository orderRepository)
        {
            _pizzaRepository = pizzaRepository;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        public void SetMutualExclusion(string resourceName)
        {
        }

        public async Task Commit()
        {
            await _orderRepository.ApplyChanges();
        }

        public void Dispose()
        {
        }
    }
}