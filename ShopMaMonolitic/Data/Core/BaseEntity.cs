namespace ShopMaMonolitic.Data.Core;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        this.CreationDate = DateTime.Now;
        this.Delected = false;
    }
    public DateTime? modifyDate { set; get; }
    public int? modifyUser { set; get; }
    public int createUser { set; get; }
    public DateTime createDate { set; get; }
    public int? deleteUser { set; get; }
    public DateTime? deleteDate { set; get; }
    public bool deleted { set; get; }
}