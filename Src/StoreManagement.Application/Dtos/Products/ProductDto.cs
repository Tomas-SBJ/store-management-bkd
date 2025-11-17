namespace StoreManagement.Application.Dtos.Products;

public record ProductDto(int Code, int StoreCode, int CompanyCode, string Name, string Description, decimal Price);