namespace ShopMaMonolitic.Data.Models;

public class ProductionProductsModel
{
    public int ProductID { get; set; }
    public DateTime ? DeletedDate { get; set; }
    public int ? DeletedUser {  get; set; }
    public bool? Deleted {  get; set; }
    public string ProductName { get; set; }
    public int categoryID { get; set; }
    public int supplierID { get; set; }
    public decimal UnitPrice { get; set; }
    public bool Discontinued { get; set; }
    public int CreatorUser {  get; set; }
    public DateTime CreationDate{ get; set; }
    public DateTime? modify_date {  get; set; }
    public int? modify_user { get; set; }

    
}