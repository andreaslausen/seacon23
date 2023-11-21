using System;

namespace PizzaOnline.Core.Application.Contracts.Dtos
{
    public struct OrderDto
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public int CustomerNumber { get; set; }
        public decimal Sum { get; set; }
    }
}