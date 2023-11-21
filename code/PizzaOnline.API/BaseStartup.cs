using Microsoft.Extensions.DependencyInjection;
using PizzaOnline.Core.Application;
using PizzaOnline.Core.Application.Contracts.Adapters;
using PizzaOnline.Core.Application.Interfaces;
using PizzaOnline.Core.Application.Mappers;
using PizzaOnline.Core.Application.Services;
using PizzaOnline.Core.Domain.Interfaces;
using PizzaOnline.Persistence.Memory;

namespace PizzaOnline.API
{
    public class BaseStartup
    {
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
            services.AddScoped<IDateTimeProvider, SystemDateTimeProvider>();

            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IMenuMapper, MenuMapper>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderMapper, OrderMapper>();
        }
    }
}