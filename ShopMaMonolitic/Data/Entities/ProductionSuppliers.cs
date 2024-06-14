using ShopMaMonolitic.Data.Core;
using System.ComponentModel.DataAnnotations;

namespace ShopMaMonolitic.Data.Entities;

public class ProductionSuppliers : BaseEntity
{
    [Key]
    public int supplierID { get; set; }
    public string companyName { get; set; }
    public string contactTitle { get; set; }
    public string contactName { get; set; }
    public string adress { get; set; }
    public string city { get; set; }
    public string? region { get; set; }
    public string? postalcode { get; set; }
    public string country { set; get; }
    public string phone { get; set; }
    public string? fax { set; get; }
    
}