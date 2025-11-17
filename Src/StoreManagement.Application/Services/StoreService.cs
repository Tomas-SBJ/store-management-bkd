using StoreManagement.Application.Dtos.Stores;
using StoreManagement.Application.Exceptions;
using StoreManagement.Application.Services.Contracts;
using StoreManagement.Domain.Entities.Companies;
using StoreManagement.Domain.Entities.Stores;
using StoreManagement.Infrastructure.Transactions;

namespace StoreManagement.Application.Services;

internal class StoreService(
    IStoreRepository storeRepository,
    ICompanyRepository companyRepository,
    IUnitOfWork unitOfWork
) : IStoreService
{
    public async Task<StoreDto> InsertAsync(int companyCode, StoreCreateDto storeCreateDto)
    {
        var company = await companyRepository.SelectOneByAsync(x => x.Code == companyCode);

        if (company is null)
            throw new EntityNotFoundException($"Company with Code {companyCode} was not found");

        var storeAlreadyExits =
            await storeRepository.ExistsAsync(x => x.Code == storeCreateDto.Code && x.CompanyId == company.Id);

        if (storeAlreadyExits)
            throw new EntityAlreadyExistsException($"Company with Code {companyCode} already exists");

        var store = await storeRepository.CreateAsync(
            Store.Create(
                storeCreateDto.Code,
                storeCreateDto.Name,
                storeCreateDto.Address,
                company
            )
        );

        await unitOfWork.Commit();

        return new StoreDto(
            store.Code,
            store.Company.Code,
            store.Name,
            store.Address
        );
    }

    public async Task<StoreDto> UpdateAsync(int code, int companyCode, StoreUpdateDto storeUpdateDto)
    {
        var store = await storeRepository.SelectOneWithCompanyAsync(code, companyCode);

        if (store is null)
            throw new EntityNotFoundException($"Store with Code {code} was not found");

        store.Update(storeUpdateDto.Name, storeUpdateDto.Address);
        await unitOfWork.Commit();

        return new StoreDto(
            store.Code,
            store.Company.Code,
            store.Name,
            store.Address
        );
    }

    public async Task DeleteAsync(int code, int companyCode)
    {
        var store = await storeRepository.SelectOneByAsync(x => x.Code == code && x.Company.Code == companyCode);

        if (store is null)
            throw new EntityNotFoundException($"Store with Code {code} was not found");

        var hasProducts = await storeRepository.HasProductsAsync(store.Id);

        if (hasProducts)
            throw new DeleteConflictException($"It is not possible to delete store that has associated products");

        storeRepository.Delete(store);
        await unitOfWork.Commit();
    }

    public async Task<StoreDto> SelectOneAsync(int code, int companyCode)
    {
        var store = await storeRepository.SelectOneWithCompanyAsync(code, companyCode);

        if (store is null)
            throw new EntityNotFoundException($"Store with code: {code} was not found");

        return new StoreDto(
            store.Code,
            store.Company.Code,
            store.Name,
            store.Address
        );
    }

    public async Task<IEnumerable<StoreDto>> SelectAllAsync(int companyCode)
    {
        var stores = await storeRepository.SelectAllByCompanyCodeAsync(companyCode);

        return stores.Select(x =>
            new StoreDto(
                x.Code,
                x.Company.Code,
                x.Name,
                x.Address)
        ).OrderBy(x => x.Code);
    }
}