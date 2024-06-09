namespace ShopMaMonolitic.Data.Core;

public abstract class BaseEntity
{
    public int productId { set; get; }
    public int orderId { set; get; }
    public int? custId { set; get; }
    public int shipperId { set; get; }
    public int empId { set; get; }
}