using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using ShopMaMonolitic.Data.Core;

namespace ShopMaMonolitic.Data.Entities;

public class Products : BaseEntity
{
    [Key]
    public int productID { get; set; }
    public string productName { get; set; }
    public decimal unitPrice { get; set; }
    public bool discontinued { get; set; }
}