using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Exceptions;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Data.DbObjetcs;
public class SalesCustumersDb : ISalesCustomersDb
{
    private readonly ShopContext context;

    public SalesCustumersDb(ShopContext context)
    {
        this.context = context;
    }

    public SalesCustomersModel GetSalesCustomers(int SalesId)
    {
        var GetsalesCustomers = this.context.SalesCustomers.Find(SalesId);

        SalesCustomersModel salesCustomersModel = new SalesCustomersModel()
        {
            CompanyName = GetsalesCustomers.CompanyName,
            ContactName = GetsalesCustomers.ContactName,
            ContactTitle = GetsalesCustomers.ContactTtitle,
            Address = GetsalesCustomers.Address,
            Email = GetsalesCustomers.Email,
            City = GetsalesCustomers.City,
            Region = GetsalesCustomers.Region,
            PostalCode = GetsalesCustomers.PostalCode,
            Country = GetsalesCustomers.Country,
            Phone = GetsalesCustomers.Phone,
            Fax = GetsalesCustomers.Fax
        };

        return salesCustomersModel;
    }

    public List<SalesCustomersModel> GetSalesCustomers()
    {
        return this.context.SalesCustomers.Select(ListSalesCustomers => new SalesCustomersModel() 
        {
            CompanyName = ListSalesCustomers.CompanyName,
            ContactName = ListSalesCustomers.ContactName,
            ContactTitle = ListSalesCustomers.ContactTtitle,
            Address = ListSalesCustomers.Address,
            Email = ListSalesCustomers.Email,
            City = ListSalesCustomers.City,
            Region = ListSalesCustomers.Region,
            PostalCode = ListSalesCustomers.PostalCode,
            Country = ListSalesCustomers.Country,
            Phone = ListSalesCustomers.Phone,
            Fax = ListSalesCustomers.Fax
        }).ToList();
    }

    public void SaveSalesCustomers(SaveSalesCustomersModel saveSalesCustomers)
    {   
        SalesCustomers salesCustomers = new SalesCustomers()
        {
            CompanyName = saveSalesCustomers.CompanyName,
            ContactName = saveSalesCustomers.ContactName,
            ContactTtitle = saveSalesCustomers.ContactTitle,
            Address = saveSalesCustomers.Address,
            Email = saveSalesCustomers.Email,
            City = saveSalesCustomers.City,
            Region = saveSalesCustomers.Region,
            PostalCode = saveSalesCustomers.PostalCode,
            Country = saveSalesCustomers.Country,
            Phone = saveSalesCustomers.Phone,
            Fax = saveSalesCustomers.Fax
        };
        this.context.SalesCustomers.Add(salesCustomers);
        this.context.SaveChanges();
    }

    public void UpdateSalesCustomers(UpdatesalesCustomersModel updatesalesCustomers)
    {
        SalesCustomers salesCustomersToUpdate = this.context.SalesCustomers.Find(updatesalesCustomers.CustId);

        if (salesCustomersToUpdate is null)
        {
            throw new SalesCustomersException("El cliente no esta registrado");
        }
            salesCustomersToUpdate.CompanyName = updatesalesCustomers.CompanyName;
            salesCustomersToUpdate.ContactName = updatesalesCustomers.ContactName;
            salesCustomersToUpdate.ContactTtitle = updatesalesCustomers.ContactTitle;
            salesCustomersToUpdate.Address = updatesalesCustomers.Address;
            salesCustomersToUpdate.Email = updatesalesCustomers.Email;
            salesCustomersToUpdate.City = updatesalesCustomers.City;
            salesCustomersToUpdate.Region = updatesalesCustomers.Region;
            salesCustomersToUpdate.PostalCode = updatesalesCustomers.PostalCode;
            salesCustomersToUpdate.Country = updatesalesCustomers.Country;
            salesCustomersToUpdate.Phone = updatesalesCustomers.Phone;
            salesCustomersToUpdate.Fax = updatesalesCustomers.Fax;

        this.context.SalesCustomers.Update(salesCustomersToUpdate);
        this.context.SaveChanges();
    }

    public void RemoveSalesCustomers(RemoveSalesCustomersModel removeSalesCustomers)
    {
        SalesCustomers salesCustomerToDelete = this.context.SalesCustomers.Find(removeSalesCustomers.CustId);

        if (salesCustomerToDelete is null)
        {
            throw new SalesCustomersException("El cliente no esta registrado");
        }

        salesCustomerToDelete.custId = removeSalesCustomers.CustId;

        this.context.SalesCustomers.Update(salesCustomerToDelete);
        this.context.SaveChanges();
    }
}