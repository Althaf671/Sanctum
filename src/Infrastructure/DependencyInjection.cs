using Microsoft.Extensions.DependencyInjection;

namespace src.Infrastructure;
public static class InfraDependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services)
    {
        return services;
    }
}