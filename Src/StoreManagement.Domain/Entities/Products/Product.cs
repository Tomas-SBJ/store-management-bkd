using StoreManagement.Domain.Entities.Abstractions;
using StoreManagement.Domain.Entities.Stores;

namespace StoreManagement.Domain.Entities.Products;

public class Product : Base
{
    public int Code { get; init; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    
    public Guid StoreId { get; private set; }
    public virtual Store Store { get; private set; }

    public static Product Create(int code, string name, string description, decimal price, Store store)
    {
        return new Product
        {
            Code = code,
            Name = name,
            Description = description,
            Price = price,
            StoreId = store.Id,
            Store = store
        };
    }
    
    public void Update(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
        UpdatedAt = DateTime.UtcNow;
    }
}