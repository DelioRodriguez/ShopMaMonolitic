using ShopMaMonolitic.Data.Core;

namespace ShopMaMonolitic.Data.Entities;

public class SalesOrders : BaseEntity
{
    public DateTime orderDate { get; set; }
    public DateTime requiredDate { get; set; }
    public DateTime? shippedDate { get; set; }
    public SqlMoney unitPrice { get; set; }
    public string shipName { get; set; }
    public string shipadDress { get; set; }
    public string shipcity { get; set; }
    public string shipRegion { get; set; }
    public string shipPostalcode { get; set; }
    public string shipCountry { get; set; }
    public SalesOrders()
    {
        
    }
}