using System.Data.SqlTypes;

namespace ShopMaMonolitic.Data.Models
{
    public class UpdateSalesOrderDetailsModel
    {
        public int OrderId { get; set; }
        public SqlMoney UnitPrice { get; set; }
        public short Qty { get; set; }
        public decimal Discount { get; set; }
    }
}
