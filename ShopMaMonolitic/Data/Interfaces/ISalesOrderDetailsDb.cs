using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Data.Interfaces;

public interface ISalesOrderDetailsDb
{
    void SaveSalesOrderDetails(SaveSalesOrderDetailsModel saveSalesOrderDetailsModel);
    void UpdateSalesOrderDetails(UpdateSalesOrderDetailsModel updateSalesOrderDetailsModel);
    List<SalesOrderDetailsModel> GetSalesOrderDetails();
    SalesOrderDetailsModel GetSalesOrderDetail(int orderId);
}