namespace ShopMaMonolitic.Data.Models;

public class UpdateSalesCustomersModel
{
    public int CustId { set; get; }
    public string CompanyName { set; get; }
    public string ContactName { set; get; }
    public string ContactTitle { set; get; }
    public string Address { set; get; }
    public string Email { set; get; }
    public string City { set; get; }
    public string? Region { set; get; }
    public string? PostalCode { set; get; }
    public string Country { set; get; }
    public string Phone { set; get; }
    public string? Fax { set; get; }
}