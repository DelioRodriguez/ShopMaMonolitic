using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.BL.Interfaces;

public interface ISalesOrderDetailsServices
{
    List<SalesOrderDetailsModel> GetSalesOrderDetails();
}