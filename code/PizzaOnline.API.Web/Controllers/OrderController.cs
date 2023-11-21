using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaOnline.Core.Application.Contracts.Dtos;
using PizzaOnline.Core.Application.Services;

namespace PizzaOnline.API.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("createOrder")]
        public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] NewOrderDto dto)
        {
            return await _orderService.CreateOrder(dto);
        }

        [HttpPut("confirm")]
        public async Task Confirm(Guid orderId)
        {
            await _orderService.ConfirmOrder(orderId);
        }
    }
}