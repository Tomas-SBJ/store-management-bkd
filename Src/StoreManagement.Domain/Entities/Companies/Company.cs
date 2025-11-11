using StoreManagement.Domain.Entities.Abstractions;

namespace StoreManagement.Domain.Entities.Companies;

public class Company : Base
{
    public int Code { get; private set; }
    public string Name { get; private set; }
    public string CountryCode { get; private set; }

    public static Company Create(int code, string name, string countryCode)
    {
        return new Company
        {
            Code = code,
            Name = name,
            CountryCode = countryCode
        };
    }

    public void Update(string name, string countryCode)
    {
        Name = name;
        CountryCode = countryCode;
        UpdatedAt = DateTime.UtcNow;
    }
}