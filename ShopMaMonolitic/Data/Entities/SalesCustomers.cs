using ShopMaMonolitic.Data.Core;

namespace ShopMaMonolitic.Data.Entities;

public class SalesCustomers : BaseEntity
{
    public string CompanyName { set; get; }
    public string ContactName { set; get; }
    public string ContactTtitle { set; get; }
    public string Address { set; get; }
    public string Email { set; get; }
    public string City { set; get; }
    public string Region { set; get; }
    public string PostalCode { set; get; }
    public string Country { set; get; }
    public string Phone { set; get; }
    public string Fax { set; get; }

    public SalesCustomers()
    {
        
    }
}