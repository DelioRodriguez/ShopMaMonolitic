namespace ShopMaMonolitic.Data.Models
{
    public class ProductionProductsRemoveModel
    {
        public int ProductID { get; set; }
        public DateTime DeletedDate { get; set; }
        public int DeletedUser {  get; set; }
        public bool Deleted { get; set; }
    }
}
