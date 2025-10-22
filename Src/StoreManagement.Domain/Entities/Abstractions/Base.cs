namespace StoreManagement.Domain.Entities.Abstractions;

public abstract class Base
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}