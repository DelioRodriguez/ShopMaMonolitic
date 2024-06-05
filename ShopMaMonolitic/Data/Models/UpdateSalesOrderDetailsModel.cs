using System.Data.SqlTypes;

namespace ShopMaMonolitic.Data.Models
{
    public class UpdateSalesOrderDetailsModel
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public SqlMoney UnitPrice { get; set; }
        public short Qty { get; set; }
        public decimal Discount { get; set; }
    }
}
