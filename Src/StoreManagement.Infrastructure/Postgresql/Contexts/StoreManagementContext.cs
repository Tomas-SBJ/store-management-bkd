using Microsoft.EntityFrameworkCore;
using StoreManagement.Domain.Entities.Companies;
using StoreManagement.Domain.Entities.Products;
using StoreManagement.Domain.Entities.Stores;
using StoreManagement.Infrastructure.Postgresql.Mappings;
using StoreManagement.Infrastructure.Postgresql.Mappings.Contracts;

namespace StoreManagement.Infrastructure.Postgresql.Contexts;

public class StoreManagementContext(DbContextOptions<StoreManagementContext> options) : DbContext(options)
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Product> Products { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var mappingTypes = typeof(BaseMapping<>).Assembly
            .GetTypes()
            .Where(x => x.IsAssignableTo(typeof(IBaseMapping)))
            .Where(x => !x.IsAbstract)
            .ToList();

        foreach (var mappingType in mappingTypes)
        {
            var mapping = Activator.CreateInstance(mappingType);
            var initializeMethod = mapping?.GetType().GetMethod(nameof(IBaseMapping.Map));
            
            initializeMethod?.Invoke(mapping, [modelBuilder]);
        }
    }
}