namespace StoreManagement.Domain.Entities.Products;

public interface IProductRepository
{
    Task<Product?> SelectOneWithHierarchyAsync(int code, int storeCode, int companyCode);
    Task<IEnumerable<Product>> SelectAllWithHierarchyAsync(int storeCode, int companyCode);
}