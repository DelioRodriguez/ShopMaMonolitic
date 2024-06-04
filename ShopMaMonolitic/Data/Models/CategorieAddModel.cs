namespace ShopMaMonolitic.Data.Models
{
    public class CategorieAddModel
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatorUser { get; set; }
    }
}
