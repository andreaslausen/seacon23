using System;

namespace PizzaOnline.Core.Application.Contracts.Dtos
{
    public struct NewOrderDto
    {
        public int CustomerNumber { get; set; }

        public OrderPositionDto[] Positions { get; set; }
    }

    public struct OrderPositionDto
    {
        public int Count { get; set; }
        public Guid PizzaId { get; set; }
    }
}