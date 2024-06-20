using System.Data.SqlTypes;

namespace ShopMaMonolitic.Data.Models
{
    public class ProductionProductsAddModel
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }
        public int categoryID { get; set; }
        public int supplierID { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatorUser {  get; set; }

    }
}
