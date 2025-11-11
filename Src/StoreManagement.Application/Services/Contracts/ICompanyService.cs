using StoreManagement.Application.Dtos.Companies;

namespace StoreManagement.Application.Services.Contracts;

public interface ICompanyService
{
    Task<CompanyDto> InsertAsync(CompanyCreateDto companyCreateDto);
    Task<CompanyDto> UpdateAsync(int code, CompanyUpdateDto companyUpdateDto);
    Task<CompanyDto?> SelectOneAsync(int code);
    Task<IEnumerable<CompanyDto>> SelectAllAsync();
    Task Delete(int code);
}