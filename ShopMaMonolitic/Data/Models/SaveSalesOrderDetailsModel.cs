namespace ShopMaMonolitic.Data.Models;

public class SaveSalesOrderDetailsModel
{
    public int OrderId { set; get; }
    public int ProductId { set; get; }
    public decimal UnitPrice { get; set; }
    public short Qty { get; set; }
    public decimal Discount { get; set; }
}