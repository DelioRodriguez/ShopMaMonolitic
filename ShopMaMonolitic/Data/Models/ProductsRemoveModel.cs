namespace ShopMaMonolitic.Data.Models
{
    public class ProductsRemoveModel
    {
        public int ProductID { get; set; }
        public DateTime DeletedDate { get; set; }
        public int DeletedUser {  get; set; }
        public bool Deleted { get; set; }
    }
}
