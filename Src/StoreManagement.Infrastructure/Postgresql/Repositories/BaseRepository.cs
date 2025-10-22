using StoreManagement.Domain.Entities.Abstractions;

namespace StoreManagement.Infrastructure.Postgresql.Repositories;

public class BaseRepository<TEntity>(
    
) : IBaseRepository<TEntity>
{
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        throw new ArgumentException();
    }
}