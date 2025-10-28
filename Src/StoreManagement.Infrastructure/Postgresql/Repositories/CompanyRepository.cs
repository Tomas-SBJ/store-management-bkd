using Microsoft.EntityFrameworkCore;
using StoreManagement.Domain.Entities.Companies;
using StoreManagement.Infrastructure.Postgresql.Contexts;

namespace StoreManagement.Infrastructure.Postgresql.Repositories;

internal class CompanyRepository(StoreManagementContext context) : BaseRepository<Company>(context), ICompanyRepository
{
    public async Task<IEnumerable<Company>> SelectAllAsync() =>
        await Entity.ToListAsync();
}