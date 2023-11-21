using System;

namespace PizzaOnline.Core.Application.Contracts.Dtos
{
    public struct PizzaPriceDto
    {
        public Guid Id { get; set; }
        public PizzaSizeDto Size { get; set; }
        public decimal Price { get; set; }
    }
}