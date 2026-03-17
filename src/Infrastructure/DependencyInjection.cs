using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using src.Modules.AcademicDomain.Interfaces;
using src.Infrastructure.Persistance;
using src.Infrastructure.Persistance.Repos;
using src.Modules.Tools.ToolsApplication.Common.Interfaces;
using src.Infrastructure.Services.ToolsServices.Converters;
using src.Infrastructure.Services.ToolsServices.Reader;

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

        services.AddScoped<IPdfConverter, LibreOfficePdfConverter>();

        services.AddScoped<IPdfMetadataReader, PdfMetadataReader>();

        services.AddScoped<IImageConverter, ImageConverter>();

        services.AddScoped<IImageMetadataReader, ImageMetadataReader>();

        services.AddScoped<IOfficeMetadataReader, OfficeMetadataReader>();

        return services;
    }
}