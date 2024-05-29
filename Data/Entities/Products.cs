using System.Data.SqlTypes;
using ShopMaMonolitic.Data.Core;

namespace ShopMaMonolitic.Data.Entities;

public class Products : BaseEntity
{
    public int productID { get; set; }
    public string productName { get; set; }
    public SqlMoney unitPrice { get; set; }
    public bool discontinued { get; set; }
}