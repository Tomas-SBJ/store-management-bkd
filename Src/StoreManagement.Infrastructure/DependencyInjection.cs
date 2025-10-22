using Microsoft.Extensions.DependencyInjection;
using StoreManagement.Domain.Entities.Companies;
using StoreManagement.Infrastructure.Postgresql.Repositories;

namespace StoreManagement.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddRepositories();
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICompanyRepository, CompanyRepository>();

        return services;
    } 
}