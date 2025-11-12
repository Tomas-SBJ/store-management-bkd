using StoreManagement.Domain.Entities.Abstractions;

namespace StoreManagement.Domain.Entities.Stores;

public interface IStoreRepository : IBaseRepository<Store>
{
    Task<List<Store>> SelectAllByCompanyCodeAsync(int companyCode);
    Task<Store?> SelectOneWithCompanyAsync(int storeCode, int companyCode);
    Task<bool> HasProductsAsync(Guid storeId);
}