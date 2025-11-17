using StoreManagement.Application.Dtos.Stores;

namespace StoreManagement.Application.Services.Contracts;

public interface IStoreService
{
    Task<StoreDto> InsertAsync(int companyCode, StoreCreateDto storeCreateDto);
    Task<StoreDto> UpdateAsync(int code, int companyCode, StoreUpdateDto storeUpdateDto);
    Task DeleteAsync(int code, int companyCode);
    Task<StoreDto> SelectOneAsync(int code, int companyCode);
    Task<IEnumerable<StoreDto>> SelectAllAsync(int companyCode);
}