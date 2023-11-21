using System;
using System.Threading.Tasks;
using PizzaOnline.Core.Application.Contracts.Adapters;
using PizzaOnline.Core.Application.Contracts.Dtos;
using PizzaOnline.Core.Application.Interfaces;
using PizzaOnline.Core.Domain.Interfaces;
using PizzaOnline.Core.Domain.Models;

namespace PizzaOnline.Core.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IOrderMapper _orderMapper;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public OrderService(IUnitOfWorkFactory unitOfWorkFactory, IOrderMapper orderMapper, IDateTimeProvider dateTimeProvider)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _orderMapper = orderMapper;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<OrderDto> CreateOrder(NewOrderDto newOrderDto)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                unitOfWork.SetMutualExclusion("OrderNumberMustBeUnique");

                var orderNumber = GetUniqueOrderNumber();
                var customer = unitOfWork.CustomerRepository.GetCustomer(newOrderDto.CustomerNumber);
                var order = new Order(orderNumber, customer, _dateTimeProvider.CurrentDateTime);

                foreach (var orderPosition in newOrderDto.Positions)
                {
                    var pizza = unitOfWork.PizzaRepository.GetPizza(orderPosition.PizzaId);
                    order.AddPizza(pizza, orderPosition.Count);
                }

                unitOfWork.OrderRepository.Insert(order);
                unitOfWork.OrderRepository.Insert(order.Positionen);
                await unitOfWork.Commit();

                return _orderMapper.Map(order);
            }
        }

        private int GetUniqueOrderNumber()
        {
            return 1;
        }

        public async Task ConfirmOrder(Guid orderId)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var order = await unitOfWork.OrderRepository.Get(orderId);

                order.Confirm();

                unitOfWork.OrderRepository.Update(order);

                await unitOfWork.Commit();
            }
        }
    }
}