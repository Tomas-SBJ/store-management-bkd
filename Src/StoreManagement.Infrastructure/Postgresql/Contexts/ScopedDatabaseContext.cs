namespace StoreManagement.Infrastructure.Postgresql.Contexts;

internal class ScopedDatabaseContext(StoreManagementContext context) : IScopedDatabaseContext
{
    public StoreManagementContext Context { get; } = context;
}