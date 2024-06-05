﻿using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Data.Interfaces;

public interface ISalesCustomersDb
{
    void SaveSalesCustomers(SaveSalesCustomersModel saveSalesCustomers);
    void UpdateSalesCustomers(UpdatesalesCustomersModel updatesalesCustomers);
    void RemoveSalesCustomers(RemoveSalesCustomersModel removeSalesCustomers);
    List<SalesCustomersModel> GetSalesCustomers();
    SalesCustomersModel GetSalesCustomers(int SalesId);
} 