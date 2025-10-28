using Microsoft.Extensions.DependencyInjection;
using StoreManagement.Application.Services;
using StoreManagement.Application.Services.Contracts;

namespace StoreManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddServices();
        
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICompanyService, CompanyService>();
        
        return services;
    }
}