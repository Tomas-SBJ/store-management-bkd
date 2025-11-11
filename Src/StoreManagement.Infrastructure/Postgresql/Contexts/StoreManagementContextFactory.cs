using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StoreManagement.Infrastructure.Postgresql.Contexts;

public class StoreManagementContextFactory : IDesignTimeDbContextFactory<StoreManagementContext>
{
    public StoreManagementContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<StoreManagementContext>();
        optionsBuilder.UseNpgsql();
        
        return new StoreManagementContext(optionsBuilder.Options);
    }
}