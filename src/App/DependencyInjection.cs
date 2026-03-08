using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using src.App.Common.Behavior;

namespace src.App.DependencyInjection;
public static class AppDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
            {
                cfg.RegisterServicesFromAssembly(typeof(AppDependencyInjection).Assembly);
                cfg.AddOpenRequestPreProcessor(typeof(LoggingBehavior<>));
                cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
                // later will add OTel
                // unhandled ex
                // and authz 
            } 
        );

        services.AddValidatorsFromAssembly(typeof(AppDependencyInjection).Assembly);

        return services;
    } 
}