namespace StoreManagement.Infrastructure.Transactions;

public interface IUnitOfWork
{
    Task Commit();
}