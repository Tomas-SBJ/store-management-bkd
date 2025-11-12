using StoreManagement.Domain.Entities.Abstractions;

namespace StoreManagement.Domain.Entities.Companies;

public interface ICompanyRepository : IBaseRepository<Company>
{
    Task<IEnumerable<Company>> SelectAllAsync();
    Task<bool> HasStoresAsync(Guid companyId);
}