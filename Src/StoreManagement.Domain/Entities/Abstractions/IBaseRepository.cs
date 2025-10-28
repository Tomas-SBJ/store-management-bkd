using System.Linq.Expressions;

namespace StoreManagement.Domain.Entities.Abstractions;

public interface IBaseRepository<TEntity>
{
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity?> SelectOneByAsync(Expression<Func<TEntity, bool>> predicate);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    void Delete(TEntity entity);
}