using Microsoft.Extensions.DependencyInjection;
using NaLibApi.Data;
using NaLibApi.Services;
using Microsoft.EntityFrameworkCore;

public static class ServiceRegistration
{
    public static void AddProjectServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add postgresql connection string to the configuration
        services.AddDbContext<NaLibDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        // Add mongodb connection string to the configuration
        services.Configure<NoSQLDbContext>(configuration.GetSection("NoSQLConnection"));

        // Add services to the container.  
        services.AddSingleton<CatalogService>();
        services.AddSingleton<CatalogEventService>();
        services.AddSingleton<ResourceTypeService>();

        // PostgreSQL
        services.AddScoped<ContactTypeService>();
    }
}