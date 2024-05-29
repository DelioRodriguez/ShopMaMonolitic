using ShopMaMonolitic.Data.Core;

namespace ShopMaMonolitic.Data.Entities;

public class SalesOrderDetails : BaseEntity
{
    public int qty { get; set; }
    public int discount { get; set; }
    public SalesOrderDetails()
    {
        
    }
    
}