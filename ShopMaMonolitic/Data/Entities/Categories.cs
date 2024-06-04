using ShopMaMonolitic.Data.Core;

namespace ShopMaMonolitic.Data.Entities;

public class Categories : BaseEntity
{
    public string categoryName { set; get; }
    public string CategoryName { get; internal set; }
    public int categoryID { set; get; }
    public string description { set; get; }
}