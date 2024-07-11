using ShopMaMonolitic.BL.Core;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.BL.Interfaces;

public interface ISalesCustomersServices
{
    ServiceResult GetSalesCustomers();
    ServiceResult GetSalesCustomer(int Id);
    ServiceResult SaveSalesCustomers(SaveSalesCustomersModel saveSalesCustomers);
    ServiceResult UpdateSalesCustomers(UpdateSalesCustomersModel updatesalesCustomers);
    ServiceResult RemoveSalesCustomers(RemoveSalesCustomersModel removeSalesCustomers);
}