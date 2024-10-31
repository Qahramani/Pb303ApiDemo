using Academy.Persistence.Contexts;
using Academy.Persistence.Repositories.Abstraction;
using Academy.Persistence.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Academy.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("AcademyDbConnection"));
        });

        services.AddScoped<IStudentRepository, StudentRepository>();
        return services;
    }
}
