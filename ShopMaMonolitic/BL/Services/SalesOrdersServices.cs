using ShopMaMonolitic.BL.Core;
using ShopMaMonolitic.BL.Interfaces;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.BL.Services;

public class SalesOrdersServices : ISalesOrdersServices
{
    private readonly ISalesOrdersDb salesOrdersDb;

    public SalesOrdersServices(ISalesOrdersDb salesOrdersDb)
    {
        this.salesOrdersDb = salesOrdersDb;
    }

    public ServiceResult GetSalesOrder(int Id)
    {
        throw new NotImplementedException();
    }

    public ServiceResult GetSalesOrders()
    {
        throw new NotImplementedException();
    }

    public ServiceResult RemoveSalesOrders(RemoveSalesOrdersModel removeSalesOrdersModel)
    {
        throw new NotImplementedException();
    }

    public ServiceResult SaveSalesOrders(SaveSalesOrdersModel saveSalesOrdersModel)
    {
        throw new NotImplementedException();
    }

    public ServiceResult UpdateSalesOrdes(UpdateSalesOrdersModels updateSalesOrdersModels)
    {
        throw new NotImplementedException();
    }
}