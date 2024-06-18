using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Data.Interfaces;

public interface ISalesOrdersDb
{
    void SaveSalesOrders(SaveSalesOrdersModel saveSalesOrdersModel);
    void UpdateSalesOrdes(UpdateSalesOrdersModels updateSalesOrdersModels);
    void RemoveSalesOrders(RemoveSalesOrdersModel removeSalesOrdersModel);
    List<SalesOrderModel> GetSalesOrders();
    SalesOrderModel GetSalesOrder(int OrderId);
}