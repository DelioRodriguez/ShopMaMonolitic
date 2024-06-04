using System.Data.SqlTypes;

namespace DefaultNamespace;

public class ProductsModel
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public SqlMoney UnitPrice { get; set; }
    public bool Discontinued { get; set; }
    public int CreatorUser {  get; set; }
    public DateTime CreationDate{ get; set; }

    
}