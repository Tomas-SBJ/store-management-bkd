namespace StoreManagement.Domain.Entities.Abstractions;

public interface IBaseRepository<TEntity>
{
    Task<TEntity> CreateAsync(TEntity entity);
}