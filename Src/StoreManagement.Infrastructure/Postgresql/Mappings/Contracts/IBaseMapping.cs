using Microsoft.EntityFrameworkCore;

namespace StoreManagement.Infrastructure.Postgresql.Mappings.Contracts;

public interface IBaseMapping
{
    void Map(ModelBuilder modelBuilder);
}