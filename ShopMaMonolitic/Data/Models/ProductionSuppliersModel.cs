namespace ShopMaMonolitic.Data.Models
{

    public class ProductionSuppliersModel
    {
        public int SuppliersID { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int? DeletedUser { get; set; }
        public bool? Deleted {  get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string? Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string? Fax { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatorUser { get; set; }

    }
}