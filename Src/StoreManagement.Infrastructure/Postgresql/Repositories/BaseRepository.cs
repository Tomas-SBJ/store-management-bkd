using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Domain.Entities.Abstractions;
using StoreManagement.Infrastructure.Postgresql.Contexts;

namespace StoreManagement.Infrastructure.Postgresql.Repositories;

public class BaseRepository<TEntity>(
    StoreManagementContext context
) : IBaseRepository<TEntity> where TEntity : Base
{
    protected readonly DbSet<TEntity> Entity = context.Set<TEntity>();
    
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        var result = await Entity.AddAsync(entity);
        return result.Entity;
    }

    public async Task<TEntity?> SelectOneByAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Entity.FirstOrDefaultAsync(predicate);
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate) =>
        await Entity.AnyAsync(predicate);

    public void Delete(TEntity entity) => Entity.Remove(entity); 
}