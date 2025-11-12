using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagement.Domain.Entities.Stores;

namespace StoreManagement.Infrastructure.Postgresql.Mappings;

public class StoreMapping : BaseMapping<Store>
{
    protected override string TableName => "companies";
    
    protected override void MapEntity(EntityTypeBuilder<Store> builder)
    {
        
    }
}