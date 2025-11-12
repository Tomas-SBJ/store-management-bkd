using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagement.Domain.Entities.Products;

namespace StoreManagement.Infrastructure.Postgresql.Mappings;

public class ProductMapping : BaseMapping<Product>
{
    protected override string TableName => "products";
    
    protected override void MapEntity(EntityTypeBuilder<Product> builder)
    {
    }
}