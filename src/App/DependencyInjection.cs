using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace src.App.DependencyInjection;
public static class AppDependencyInjection
{
    public static IServiceCollection App(this IServiceCollection services)
    {
        services.AddMediatR(
            cfg => cfg.RegisterServicesFromAssembly(typeof(AppDependencyInjection).Assembly));

        services.AddValidatorsFromAssembly(typeof(AppDependencyInjection).Assembly);

        return services;
    } 
}