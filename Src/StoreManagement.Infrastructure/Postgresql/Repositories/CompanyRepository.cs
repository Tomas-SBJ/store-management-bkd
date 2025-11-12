using Microsoft.EntityFrameworkCore;
using StoreManagement.Domain.Entities.Companies;
using StoreManagement.Infrastructure.Postgresql.Contexts;

namespace StoreManagement.Infrastructure.Postgresql.Repositories;

internal class CompanyRepository(
    IScopedDatabaseContext scopedContext
) : BaseRepository<Company>(scopedContext.Context), ICompanyRepository
{
    public async Task<IEnumerable<Company>> SelectAllAsync() =>
        await Entity.ToListAsync();
    
    public async Task<bool> HasStoresAsync(Guid companyId) =>
        await scopedContext.Context.Stores.AnyAsync(x => x.CompanyId == companyId);
}