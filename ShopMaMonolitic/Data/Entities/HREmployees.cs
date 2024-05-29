using ShopMaMonolitic.Data.Core;

namespace ShopMaMonolitic.Data.Entities;

public class HREmployees : BaseEntity
{
    public string lastName { get; set; }
    public string firstName { get; set; }
    public string title { get; set; }
    public string titleOfCurtesy { get; set; }
    public DateTime birthdate { get; set; }
    public DateTime hireDate { get; set; }
    public string city { get; set; }
    public string? region { get; set; }
    public string? postalCode { get; set; }
    public string country { set; get; }
    
    public int? MgrId { get; set; }
}