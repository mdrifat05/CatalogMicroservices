using Catalog.Application.Data;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Data.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Catalog");

        // Add services to the container.
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.AddInterceptors(new AuditableEntityInterceptor());
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IAppDbContext, AppDbContext>();

        return services;
    }
}
