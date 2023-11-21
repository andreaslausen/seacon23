using PizzaOnline.Core.Application.Contracts.Dtos;
using PizzaOnline.Core.Domain.Models;

namespace PizzaOnline.Core.Application.Interfaces
{
    public interface IMenuMapper
    {
        MenuDto ToDto(Menu menu);
    }
}