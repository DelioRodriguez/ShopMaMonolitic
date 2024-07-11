using ShopMaMonolitic.BL.Core;
using ShopMaMonolitic.BL.Interfaces;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.BL.Services;

public class SalesOrderDetailsServices : ISalesOrderDetailsServices
{
    private readonly ISalesOrderDetailsDb salesOrderDetailsDb;

    public SalesOrderDetailsServices(ISalesOrderDetailsDb salesOrderDetailsDb)
    {
        this.salesOrderDetailsDb = salesOrderDetailsDb;
    }

    public ServiceResult GetSalesOrderDetails()
    {
        throw new NotImplementedException();
    }

    public ServiceResult GetSalesOrderDetail(int Id)
    {
        throw new NotImplementedException();
    }

    public ServiceResult SaveSalesOrderDetails(SaveSalesOrderDetailsModel saveSalesOrderDetailsModel)
    {
        throw new NotImplementedException();
    }

    public ServiceResult UpdateSalesOrderDetails(UpdateSalesOrderDetailsModel updateSalesOrderDetailsModel)
    {
        throw new NotImplementedException();
    }

    public ServiceResult RemoveSalesOrderDetails(RemoveSalesOrderDetailsModel removeSalesOrderDetailsModel)
    {
        throw new NotImplementedException();
    }
}