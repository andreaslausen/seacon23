using PizzaOnline.Core.Application.Contracts.Dtos;

namespace PizzaOnline.Core.Application.Services
{
    public interface IMenuService
    {
        MenuDto GetMenu();
    }
}