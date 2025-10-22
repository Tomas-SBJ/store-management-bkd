using StoreManagement.Domain.Entities.Companies;
using StoreManagement.Infrastructure.Postgresql.Contexts;

namespace StoreManagement.Infrastructure.Postgresql.Repositories;

internal class CompanyRepository(StoreManagementContext context) : BaseRepository<Company>(context), ICompanyRepository
{
}