using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Data.Interfaces;

public interface ISalesOrderDetailsDb
{
    void SaveSalesOrderDetails(SaveSalesOrderDetailsModel saveSalesOrderDetailsModel);
    void UpdateSalesOrderDetails(UpdateSalesOrderDetailsModel updateSalesOrderDetailsModel);
    void RemoveSalesOrderDetails(RemoveSalesOrderDetailsModel removeSalesOrderDetailsModel);
    List<SalesOrderDetailsModel>  GetSalesOrderDetails();
    SalesOrderDetailsModel GetSalesOrderDetail(int orderId);
}