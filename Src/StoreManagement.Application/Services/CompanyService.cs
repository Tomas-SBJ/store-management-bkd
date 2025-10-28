using StoreManagement.Application.Dtos.Companies;
using StoreManagement.Application.Exceptions;
using StoreManagement.Application.Services.Contracts;
using StoreManagement.Domain.Entities.Companies;

namespace StoreManagement.Application.Services;

internal class CompanyService(
    ICompanyRepository companyRepository
) : ICompanyService
{
    public async Task<CompanyDto> InsertAsync(CompanyCreateDto companyCreateDto)
    {
        var companyAlreadyExists = await companyRepository.ExistsAsync(x => x.Code == companyCreateDto.Code);

        if (companyAlreadyExists)
            throw new EntityAlreadyExistsException($"Company with Code {companyCreateDto.Code} already exists");

        var company = await companyRepository.CreateAsync(Company.Create(companyCreateDto.Code, companyCreateDto.Name));

        return new CompanyDto(company.Code, company.Name);
    }

    public async Task<CompanyDto?> SelectOneAsync(int code)
    {
        var company = await companyRepository.SelectOneByAsync(x => x.Code == code);

        if (company is null)
            throw new EntityNotFoundException($"Company with Code {code} not found");
        
        return new CompanyDto(company.Code, company.Name);
    }

    public async Task<IEnumerable<CompanyDto>> SelectAllAsync()
    {
        var companies = await companyRepository.SelectAllAsync();
        return companies.Select(company => new CompanyDto(company.Code, company.Name));
    }
}