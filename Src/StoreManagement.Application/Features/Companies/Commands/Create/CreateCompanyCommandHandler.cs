using MediatR;
using StoreManagement.Application.Features.Companies.Dtos;
using StoreManagement.Domain.Entities.Companies;

namespace StoreManagement.Application.Features.Companies.Commands.Create;

public sealed class CreateCompanyCommandHandler(
    ICompanyRepository companyRepository
) : IRequestHandler<CreateCompanyCommand, CompanyDto>
{
    public async Task<CompanyDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        return new CompanyDto();
    }
}