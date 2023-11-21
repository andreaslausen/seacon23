using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaOnline.Core.Domain.Models;

namespace PizzaOnline.Core.Domain.Interfaces
{
    public interface IOrderRepository
    {
        void Insert(Order order);
        void Insert(IEnumerable<OrderPosition> orderPositions);
        void Update(Order order);
        Task<Order> Get(Guid orderNumber);
    }
}