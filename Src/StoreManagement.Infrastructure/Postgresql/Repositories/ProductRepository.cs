using Microsoft.EntityFrameworkCore;
using StoreManagement.Domain.Entities.Products;
using StoreManagement.Infrastructure.Postgresql.Contexts;

namespace StoreManagement.Infrastructure.Postgresql.Repositories;

internal class ProductRepository(
    IScopedDatabaseContext scopedContext
) : BaseRepository<Product>(scopedContext.Context), IProductRepository
{
    public async Task<Product?> SelectOneWithHierarchyAsync(int code, int storeCode, int companyCode) =>
        await Entity
            .Include(product => product.Store)
            .ThenInclude(store => store.Company)
            .FirstOrDefaultAsync(product =>
                product.Code == code &&
                product.Store.Code == storeCode &&
                product.Store.Company.Code == companyCode);

    public async Task<IEnumerable<Product>> SelectAllWithHierarchyAsync(int storeCode, int companyCode) =>
        await Entity
            .Include(product => product.Store)
            .ThenInclude(store => store.Company)
            .Where(product => product.Store.Code == storeCode && product.Store.Company.Code == companyCode)
            .ToListAsync();
}