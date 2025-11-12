using Microsoft.EntityFrameworkCore;
using StoreManagement.Domain.Entities.Stores;
using StoreManagement.Infrastructure.Postgresql.Contexts;

namespace StoreManagement.Infrastructure.Postgresql.Repositories;

internal class StoreRepository(
    IScopedDatabaseContext scopedContext
) : BaseRepository<Store>(scopedContext.Context), IStoreRepository
{
    public async Task<List<Store>> SelectAllByCompanyCodeAsync(int companyCode) =>
        await Entity
            .Include(x => x.Company)
            .Where(x => x.Company.Code == companyCode)
            .ToListAsync();

    public async Task<Store?> SelectOneWithCompanyAsync(int storeCode, int companyCode) =>
        await Entity
            .Include(x => x.Company)
            .FirstOrDefaultAsync(x => x.Code == storeCode && x.Company.Code == companyCode);

    public async Task<bool> HasProductsAsync(Guid storeId) =>
        await scopedContext.Context.Products.AnyAsync(x => x.StoreId == storeId);
}