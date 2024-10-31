using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Persistence.Repositories.Contracts;
using Shop.Persistence.Repositories;
using Shop.Application.Services.Contracts;
using Shop.Application.Services;
using System.Reflection;

namespace Shop.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IProductService, ProductManager>();

        return services;
    }
}
