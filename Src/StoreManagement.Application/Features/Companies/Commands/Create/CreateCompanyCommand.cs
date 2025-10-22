using MediatR;
using StoreManagement.Application.Features.Companies.Dtos;

namespace StoreManagement.Application.Features.Companies.Commands.Create;

public record CreateCompanyCommand(int Code, string Name) : IRequest<CompanyDto>;