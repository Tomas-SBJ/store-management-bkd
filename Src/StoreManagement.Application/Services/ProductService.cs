using StoreManagement.Application.Dtos.Products;
using StoreManagement.Application.Exceptions;
using StoreManagement.Application.Services.Contracts;
using StoreManagement.Domain.Entities.Products;
using StoreManagement.Domain.Entities.Stores;
using StoreManagement.Infrastructure.Transactions;

namespace StoreManagement.Application.Services;

internal class ProductService(
    IProductRepository productRepository,
    IStoreRepository storeRepository,
    IUnitOfWork unitOfWork
) : IProductService
{
    public async Task<ProductDto> InsertAsync(int storeCode, int companyCode, ProductCreateDto productCreateDto)
    {
        var store = await storeRepository.SelectOneWithCompanyAsync(storeCode, companyCode);

        if (store is null)
            throw new EntityNotFoundException($"Store with code {storeCode} was not found");

        var productAlreadyExists =
            await productRepository.ExistsAsync(x => x.Code == productCreateDto.Code && x.StoreId == store.Id);

        if (productAlreadyExists)
            throw new EntityAlreadyExistsException($"Product with code {productCreateDto.Code} already exists");

        var product = await productRepository.CreateAsync(
            Product.Create(
                productCreateDto.Code,
                productCreateDto.Name,
                productCreateDto.Descripnion,
                productCreateDto.Price,
                store
            )
        );

        await unitOfWork.Commit();

        return new ProductDto(
            product.Code,
            product.Store.Code,
            product.Store.Company.Code,
            product.Name,
            product.Description,
            product.Price
        );
    }

    public async Task<ProductDto> UpdateAsync(int code, int storeCode, int companyCode,
        ProductUpdateDto productUpdateDto)
    {
        var product = await productRepository.SelectOneWithHierarchyAsync(code, storeCode, companyCode);

        if (product is null)
            throw new EntityNotFoundException($"Product with code {code} was not found");

        product.Update(productUpdateDto.Name, productUpdateDto.Description, productUpdateDto.Price);
        await unitOfWork.Commit();

        return new ProductDto(
            product.Code,
            product.Store.Code,
            product.Store.Company.Code,
            product.Name,
            product.Description,
            product.Price
        );
    }

    public async Task<ProductDto> SelectOneAsync(int code, int storeCode, int companyCode)
    {
        var product = await productRepository.SelectOneWithHierarchyAsync(code, storeCode, companyCode);

        if (product is null)
            throw new EntityNotFoundException($"Product with code {code} was not found");

        return new ProductDto(
            product.Code,
            product.Store.Code,
            product.Store.Company.Code,
            product.Name,
            product.Description,
            product.Price
        );
    }

    public async Task<IEnumerable<ProductDto>> SelectAllByStoreAsync(int storeCode, int companyCode)
    {
        var products = await productRepository.SelectAllWithHierarchyAsync(storeCode, companyCode);

        return products.Select(x =>
            new ProductDto(
                x.Code,
                x.Store.Code,
                x.Store.Company.Code,
                x.Name,
                x.Description,
                x.Price
            )
        ).OrderBy(x => x.Code);
    }

    public async Task DeleteAsync(int code, int storeCode, int companyCode)
    {
        var product = await productRepository.SelectOneWithHierarchyAsync(code, storeCode, companyCode);
        
        if (product is null)
            throw new EntityNotFoundException($"Product with code {code} was not found");
        
        productRepository.Delete(product);
        await unitOfWork.Commit();
    }
}