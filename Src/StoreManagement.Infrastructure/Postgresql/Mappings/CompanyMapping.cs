using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagement.Domain.Entities.Companies;

namespace StoreManagement.Infrastructure.Postgresql.Mappings;

public class CompanyMapping : BaseMapping<Company>
{
    protected override string TableName => "companies";

    protected override void MapEntity(EntityTypeBuilder<Company> builder)
    {
        builder.Property(x => x.Code).HasColumnName("code").IsRequired();
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(25).IsRequired();
    }
}