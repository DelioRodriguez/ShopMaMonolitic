namespace ShopMaMonolitic.Data.Models
{
    public class CategoriesUpdateModel
    {
        
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int ModifyUser {  get; set; }


    }
}
