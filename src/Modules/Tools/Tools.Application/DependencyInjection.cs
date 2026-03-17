using Microsoft.Extensions.DependencyInjection;

namespace src.Modules.Tools.ToolsApplication;

public static class ToolsApplicationDI
{
    public static IServiceCollection AddToolsApplication(this IServiceCollection services)
    {
        services.AddMediatR(
            cfg => cfg.RegisterServicesFromAssembly(typeof(ToolsApplicationDI).Assembly));

        return services;
    }
}