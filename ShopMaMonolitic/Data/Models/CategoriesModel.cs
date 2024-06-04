namespace ShopMaMonolitic.Data.Models;

public class CategoriesModel
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public int CreaterUser {  get; set; }
    public DateTime CreateDate { get; set; }
    public object Categories { get; internal set; }
}