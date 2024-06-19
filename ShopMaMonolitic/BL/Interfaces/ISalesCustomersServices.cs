using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.BL.Interfaces;

public interface ISalesCustomersServices
{
    List<SalesCustomersModel> GetSalesCustomers();
}