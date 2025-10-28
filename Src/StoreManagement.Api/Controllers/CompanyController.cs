using Microsoft.AspNetCore.Mvc;
using StoreManagement.Application.Dtos.Companies;
using StoreManagement.Application.Services.Contracts;

namespace StoreManagement.Api.Controllers;

[Route("api/[controller]")]
public class CompanyController(
    ICompanyService companyService
) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCompany(CompanyCreateDto createDto)
    {
        var result = await companyService.InsertAsync(createDto);

        return CreatedAtRoute("/api/companies", result);
    }

    [HttpGet("{code:int}")]
    public async Task<IActionResult> GetCompany(int code)
    {
        return Ok(await companyService.SelectOneAsync(code));
    }

    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        return Ok(await companyService.SelectAllAsync());
    }
}