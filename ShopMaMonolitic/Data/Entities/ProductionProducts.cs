using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using ShopMaMonolitic.Data.Core;

namespace ShopMaMonolitic.Data.Entities;
[Table("Products",Schema ="Production")]
public class ProductionProducts : BaseEntity
{
    [Key]
    public int productID { get; set; }
    public int categoryID { get; set; }
    public int supplierID { get; set; }
    public string productName { get; set; }
    public decimal unitPrice { get; set; }
    public bool discontinued { get; set; }
}