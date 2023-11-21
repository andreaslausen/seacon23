using Microsoft.AspNetCore.Mvc;
using PizzaOnline.Core.Application.Contracts.Dtos;
using PizzaOnline.Core.Application.Services;

namespace PizzaOnline.API.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public ActionResult<MenuDto> Get()
        {
            return _menuService.GetMenu();
        }
    }
}