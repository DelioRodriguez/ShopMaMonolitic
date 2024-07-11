using ShopMaMonolitic.BL.Core;
using ShopMaMonolitic.Data.Models;
using ShopMaMonolitic.Data.Core;

namespace ShopMaMonolitic.BL.Interfaces;

public interface ISalesOrdersServices
{
    ServiceResult GetSalesOrders();
    ServiceResult GetSalesOrder(int Id);
    ServiceResult SaveSalesOrders(SaveSalesOrdersModel saveSalesOrdersModel);
    ServiceResult UpdateSalesOrdes(UpdateSalesOrdersModels updateSalesOrdersModels);
    ServiceResult RemoveSalesOrders(RemoveSalesOrdersModel removeSalesOrdersModel);
}