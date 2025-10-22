using StoreManagement.Domain.Entities.Abstractions;

namespace StoreManagement.Domain.Entities.Companies;

public class Company : Base
{
    public int Code { get; private set; }
    public string Name { get; private set; }

    public Company Create(int code, string name)
    {
        return new Company
        {
            Code = code,
            Name = name
        };
    }
}