using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.BL.Interfaces;

public interface ISalesOrdersServices
{
    List<SalesOrderModel> GetSalesOrders();
}