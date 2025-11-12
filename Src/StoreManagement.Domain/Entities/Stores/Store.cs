using StoreManagement.Domain.Entities.Abstractions;
using StoreManagement.Domain.Entities.Companies;
using StoreManagement.Domain.Entities.Products;

namespace StoreManagement.Domain.Entities.Stores;

public class Store : Base
{
    public int Code { get; init; }
    public string Name { get; private set; }
    public string Address { get; private set; }

    public Guid CompanyId { get; private set; }
    public virtual Company Company { get; private set; }
    public virtual ICollection<Product> Products { get; private set; } = [];

    public Store Create(int code, string name, string address, Company company)
    {
        return new Store
        {
            Code = code,
            Name = name,
            Address = address,
            CompanyId = company.Id,
            Company = company
        };
    }

    public void Update(string name, string address)
    {
        Name = name;
        Address = address;
        UpdatedAt = DateTime.Now;
    }
}