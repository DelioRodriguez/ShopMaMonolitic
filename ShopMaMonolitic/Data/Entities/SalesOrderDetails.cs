namespace ShopMaMonolitic.Data.Core;

public class SalesOrderDetails : BaseEntity
{
    public int qty { get; set; }
    public int discount { get; set; }
    public SalesOrderDetails()
    {
        
    }
    
}