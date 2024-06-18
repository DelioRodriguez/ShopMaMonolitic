using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShopMaMonolitic.Data.Core;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;

namespace ShopMaMonolitic.Data.Entities;

[Table("OrderDetails", Schema = "Sales")]
public class SalesOrderDetails
{
    [Key]
    public int OrderId { set; get; }
    public int ProductId { set; get; }
    public decimal UnitPrice {  get; set; }
    public short Qty { get; set; }
    public decimal Discount { get; set; }
}