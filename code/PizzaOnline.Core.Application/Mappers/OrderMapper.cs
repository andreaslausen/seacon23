using PizzaOnline.Core.Application.Contracts.Dtos;
using PizzaOnline.Core.Application.Interfaces;
using PizzaOnline.Core.Domain.Models;

namespace PizzaOnline.Core.Application.Mappers
{
    public class OrderMapper : IOrderMapper
    {
        public OrderDto Map(Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                Number = order.Number,
                CustomerNumber = order.Customer.Number,
                Sum = order.CalculateSum()
            };
        }
    }
}