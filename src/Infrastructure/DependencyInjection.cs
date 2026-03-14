using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using src.Modules.AcademicDomain.Interfaces;
using src.Infrastructure.Persistance;
using src.Infrastructure.Persistance.Repos;

namespace src.Infrastructure;
public static class InfraDependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IMataKuliahRepository, MataKuliahRepository>();

        return services;
    }
}