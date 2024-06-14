using System.Data.SqlTypes;

namespace DefaultNamespace;

public class ProductionProductsModel
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public bool Discontinued { get; set; }
    public int CreatorUser {  get; set; }
    public DateTime CreationDate{ get; set; }

    
}