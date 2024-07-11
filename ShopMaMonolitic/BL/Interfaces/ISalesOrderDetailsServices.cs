using ShopMaMonolitic.BL.Core;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.BL.Interfaces;

public interface ISalesOrderDetailsServices
{
    ServiceResult GetSalesOrderDetails();
    ServiceResult GetSalesOrderDetail(int Id);
    ServiceResult SaveSalesOrderDetails(SaveSalesOrderDetailsModel saveSalesOrderDetailsModel);
    ServiceResult UpdateSalesOrderDetails(UpdateSalesOrderDetailsModel updateSalesOrderDetailsModel);
    ServiceResult RemoveSalesOrderDetails(RemoveSalesOrderDetailsModel removeSalesOrderDetailsModel);
}