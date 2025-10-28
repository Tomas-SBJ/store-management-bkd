namespace StoreManagement.Infrastructure.Postgresql.Contexts;

public interface IScopedDatabaseContext
{
    StoreManagementContext Context { get; }
}