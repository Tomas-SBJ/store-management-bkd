using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagement.Domain.Entities.Products;

namespace StoreManagement.Infrastructure.Postgresql.Mappings;

public class ProductMapping : BaseMapping<Product>
{
    protected override string TableName => "products";
    
    protected override void MapEntity(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Code).HasColumnName("code").IsRequired();
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(25).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Price).HasColumnName("price").HasPrecision(18, 2).IsRequired();
        builder.Property(x => x.StoreId).HasColumnName("store_id").IsRequired();
        
        builder
            .HasOne(product => product.Store)
            .WithMany(store => store.Products)
            .HasForeignKey(product => product.StoreId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasIndex(x => new { x.Code, x.StoreId }).IsUnique();
    }
}