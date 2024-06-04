using System.Data.SqlTypes;

namespace ShopMaMonolitic.Data.Models
{
    public class ProductsUpdateModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int ModifyUser {  get; set; }
        public SqlMoney UnitPrice { get; set; }
        public bool Discontinued { get; set; }
    }
}
