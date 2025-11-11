using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagement.Domain.Entities.Abstractions;
using StoreManagement.Infrastructure.Postgresql.Mappings.Contracts;

namespace StoreManagement.Infrastructure.Postgresql.Mappings;

public abstract class BaseMapping<TEntity> : IBaseMapping where TEntity : Base
{
    protected abstract string TableName { get; }

    public void Map(ModelBuilder modelBuilder)
    {
        var entityBuilder = modelBuilder.Entity<TEntity>();

        MapBase(entityBuilder);
        MapEntity(entityBuilder);
    }

    private void MapBase(EntityTypeBuilder<TEntity> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
        builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
    }

    protected abstract void MapEntity(EntityTypeBuilder<TEntity> builder);
}