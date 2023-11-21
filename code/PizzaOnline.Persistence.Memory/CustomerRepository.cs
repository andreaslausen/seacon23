using System;
using PizzaOnline.Core.Domain.Interfaces;
using PizzaOnline.Core.Domain.Models;

namespace PizzaOnline.Persistence.Memory
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetCustomer(int customerNumber)
        {
            return new Customer(Guid.NewGuid(), customerNumber, default, default, default);
        }
    }
}