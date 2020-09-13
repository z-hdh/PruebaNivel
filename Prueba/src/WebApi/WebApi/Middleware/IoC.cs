using Microsoft.Extensions.DependencyInjection;
using Prueba.Application.Helpers;
using Prueba.Application.Services;
using Prueba.Data.Generic;
using Prueba.Data.Repositories;
using Prueba.Domain.Generic;
using Prueba.Domain.Repositories;

namespace Prueba.API.Middleware
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Servicios de la capa de aplicación
            services.AddScoped<IProductServices, ProductServices>();

            // Helpers de la capa de aplicación
            services.AddScoped<IProductHelper, ProductHelper>();

            // Repositorios
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
