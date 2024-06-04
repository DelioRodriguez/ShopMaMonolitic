using System.Data.SqlTypes;

namespace ShopMaMonolitic.Data.Models
{
    public class ProductsAddModel
    {
        public string ProductName { get; set; }
        public SqlMoney UnitPrice { get; set; }
        public bool Discontinued { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatorUser {  get; set; }

    }
}
