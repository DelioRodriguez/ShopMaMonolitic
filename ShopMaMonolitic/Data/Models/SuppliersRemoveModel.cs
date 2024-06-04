namespace ShopMaMonolitic.Data.Models
{
    public class SuppliersRemoveModel
    {
        public int SupplierId { get; set; }
        public DateTime DeleteDate { get; set; }
        public int DeletedUser {  get; set; }
        public bool Deleted {  get; set; }
    }
}
