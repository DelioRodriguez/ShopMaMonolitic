using ShopMaMonolitic.BL.Interfaces;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.BL.Services;

public class SalesCustomersServices : ISalesCustomersServices
{
    private readonly ISalesCustomersDb salesCustomersDb;

    public SalesCustomersServices(ISalesCustomersDb salesCustomersDb)
    {
        this.salesCustomersDb = salesCustomersDb;
    }

    public List<SalesCustomersModel> GetSalesCustomers()
    {
        return salesCustomersDb.GetSalesCustomers();
    }
}