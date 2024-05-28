using ShopMaMonolitic.Data.Core;

namespace ShopMaMonolitic.Data.Entities;

public class Suppliers : BaseEntity
{
    public int supplierID { get; set; }
    public string companyName { get; set; }
    public string contactTitle { get; set; }
    public string city { get; set; }
    public string? region { get; set; }
    public string? postalcode { get; set; }
    public string country { set; get; }
    public string phone { get; set; }
    public string? fax { set; get; }
    
}