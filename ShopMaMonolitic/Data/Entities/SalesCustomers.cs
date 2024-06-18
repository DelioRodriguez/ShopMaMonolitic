using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShopMaMonolitic.Data.Core;

namespace ShopMaMonolitic.Data.Entities;

[Table("Customers", Schema = "Sales")]
public class SalesCustomers : BaseEntity
{
    [Key]
    public int CustId { set; get; }
    public string? ContactName { set; get; }
    public string? ContactTitle { set; get; }
    public string? Address { set; get; }
    public string? Email { set; get; }
    public string? City { set; get; }
    public string? Region { set; get; }
    public string? PostalCode { set; get; }
    public string? Country { set; get; }
    public string? Phone { set; get; }
    public string? Fax { set; get; }
}