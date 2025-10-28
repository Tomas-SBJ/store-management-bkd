using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreManagement.Domain.Entities.Companies;
using StoreManagement.Infrastructure.Postgresql.Contexts;
using StoreManagement.Infrastructure.Postgresql.Repositories;
using StoreManagement.Infrastructure.Transactions;

namespace StoreManagement.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddRepositories()
            .AddPostgresql(configuration);
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICompanyRepository, CompanyRepository>();

        return services;
    }

    private static IServiceCollection AddPostgresql(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Postgresql");

        services.AddDbContext<StoreManagementContext>(options =>
            options.UseNpgsql(connectionString, builder => { builder.EnableRetryOnFailure(); }));

        services.AddScoped<IScopedDatabaseContext, ScopedDatabaseContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}