using ShopMaMonolitic.Data.Core;
using System.Data.SqlTypes;

namespace ShopMaMonolitic.Data.Entities;

public class SalesOrderDetails : BaseEntity
{
    public SqlMoney unitPrice {  get; set; }
    public short Qty { get; set; }
    public decimal Discount { get; set; }
}