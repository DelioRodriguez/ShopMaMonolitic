namespace ShopMaMonolitic.Data.Models
{
    public class ProductionCategoriesRemoveModel
    {
        public int CategoryId { get; set; }
        public int? Deleteuser { get; set; }
       
        public DateTime DeleteDate { get; set; }
        public bool? Deleted {get; set;}

    }
}
