using System.Data.SqlTypes;

namespace ShopMaMonolitic.Data.Models
{
    public class ProductionProductsUpdateModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int categoryID { get; set; }
        public int supplierID { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int ModifyUser {  get; set; }
        public decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }
    }
}
