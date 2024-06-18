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
    public List<SalesOrderModel> GetSalesOrders()
    {
        return this.salesOrdersDb.GetSalesOrders();
    }
}