using StoreManagement.Application.Dtos.Companies;

namespace StoreManagement.Application.Services.Contracts;

public interface ICompanyService
{
    Task<CompanyDto> InsertAsync(CompanyCreateDto companyCreateDto);
    Task<CompanyDto?> SelectOneAsync(int code);
    Task<IEnumerable<CompanyDto>> SelectAllAsync();
}