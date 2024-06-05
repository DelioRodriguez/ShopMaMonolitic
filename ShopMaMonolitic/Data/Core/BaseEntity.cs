namespace ShopMaMonolitic.Data.Core;

public abstract class BaseEntity
{
    public int productId { set; get; }
    public int orderId { set; get; }
    public int? custId { set; get; }
    public int shipperId { set; get; }
    public int empid { set; get; }
    /*
    public DateTime CreationDate { get; set; }
    public bool Delected { get; }
    protected BaseEntity()
    {
        this.CreationDate = DateTime.Now;
        this.Delected = false;
    }
    */
}