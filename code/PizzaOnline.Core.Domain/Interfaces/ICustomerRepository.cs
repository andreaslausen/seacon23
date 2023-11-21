using PizzaOnline.Core.Domain.Models;

namespace PizzaOnline.Core.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int customerNumber);
    }
}