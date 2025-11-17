using StoreManagement.Application.Dtos.Products;

namespace StoreManagement.Application.Services.Contracts;

public interface IProductService
{
    Task<ProductDto> InsertAsync(int storeCode, int companyCode, ProductCreateDto productCreateDto);
    Task<ProductDto> UpdateAsync(int code, int storeCode, int companyCode, ProductUpdateDto productUpdateDto);
    Task<ProductDto> SelectOneAsync(int code, int storeCode, int companyCode);
    Task<IEnumerable<ProductDto>> SelectAllByStoreAsync(int storeCode, int companyCode);
    Task DeleteAsync(int code, int storeCode, int companyCode);
}