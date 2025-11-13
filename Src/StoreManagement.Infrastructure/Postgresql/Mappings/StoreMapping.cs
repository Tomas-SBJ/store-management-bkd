using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagement.Domain.Entities.Stores;

namespace StoreManagement.Infrastructure.Postgresql.Mappings;

public class StoreMapping : BaseMapping<Store>
{
    protected override string TableName => "stores";

    protected override void MapEntity(EntityTypeBuilder<Store> builder)
    {
        builder.Property(store => store.Code).HasColumnName("code").IsRequired();
        builder.Property(store => store.Name).HasColumnName("name").HasMaxLength(25).IsRequired();
        builder.Property(store => store.Address).HasColumnName("address").HasMaxLength(50).IsRequired();
        builder.Property(store => store.CompanyId).HasColumnName("company_id").IsRequired();

        builder
            .HasOne(store => store.Company)
            .WithMany(company => company.Stores)
            .HasForeignKey(store => store.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(store => store.Products)
            .WithOne(product => product.Store)
            .HasForeignKey(product => product.StoreId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(store => new { store.Code, store.CompanyId }).IsUnique();
    }
}