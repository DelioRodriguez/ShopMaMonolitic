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

    public List<SalesOrderDetailsModel> GetSalesOrderDetails()
    {
        return salesOrderDetailsDb.GetSalesOrderDetails();
    }
}