using ShopMaMonolitic.Data.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMaMonolitic.Data.Entities;

[Table("Categories", Schema = "Production")]
public class ProductionCategories : BaseEntity
{
    
    [Key]
    public int categoryID { set; get; }
    public string CategoryName { get; internal set; }
  
    public string description { set; get; }
}