namespace ShopMaMonolitic.Data.Models;

public class ProductionCategoriesModel
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public int CreaterUser {  get; set; }
    public DateTime CreateDate { get; set; }
    
    public DateTime? modify_date { set; get; }
    public int? modify_user { set; get; }
   
}