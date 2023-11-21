using System;
using System.Threading.Tasks;
using PizzaOnline.Core.Application.Contracts.Dtos;

namespace PizzaOnline.Core.Application.Services
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrder(NewOrderDto newOrderDto);
        Task ConfirmOrder(Guid orderId);
    }
}