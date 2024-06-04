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
            companyName = GetsalesCustomers.companyName,
            contactName = GetsalesCustomers.contactName,
            contactTitle = GetsalesCustomers.contactTtitle,
            address = GetsalesCustomers.addess,
            email = GetsalesCustomers.email,
            city = GetsalesCustomers.city,
            region = GetsalesCustomers.region,
            postalCode = GetsalesCustomers.postalCode,
            country = GetsalesCustomers.country,
            phone = GetsalesCustomers.phone,
            fax = GetsalesCustomers.fax
        };

        return salesCustomersModel;
    }

    public List<SalesCustomersModel> GetSalesCustomers()
    {
        return this.context.SalesCustomers.Select(ListSalesCustomers => new SalesCustomersModel() 
        {
            companyName = ListSalesCustomers.companyName,
            contactName = ListSalesCustomers.contactName,
            contactTitle = ListSalesCustomers.contactTtitle,
            address = ListSalesCustomers.addess,
            email = ListSalesCustomers.email,
            city = ListSalesCustomers.city,
            region = ListSalesCustomers.region,
            postalCode = ListSalesCustomers.postalCode,
            country = ListSalesCustomers.country,
            phone = ListSalesCustomers.phone,
            fax = ListSalesCustomers.fax
        }).ToList();
    }

    public void RemoveSalesCustomers(RemoveSalesCustomersModel removeSalesCustomers)
    {
        SalesCustomers salesCustomerToDelete = this.context.SalesCustomers.Find(removeSalesCustomers.custId);

        if (salesCustomerToDelete is null) 
        {
            throw new SalesCustomersException("El cliente no esta registrado");
        }

        salesCustomerToDelete.custId = removeSalesCustomers.custId;

        this.context.SalesCustomers.Update(salesCustomerToDelete);
        this.context.SaveChanges();
    }

    public void SaveSalesCustomers(SaveSalesCustomersModel saveSalesCustomers)
    {
        SalesCustomers salesCustomers = new SalesCustomers()
        {
            companyName = saveSalesCustomers.companyName,
            contactName = saveSalesCustomers.contactName,
            contactTtitle = saveSalesCustomers.contactTitle,
            addess = saveSalesCustomers.address,
            email = saveSalesCustomers.email,
            city = saveSalesCustomers.city,
            region = saveSalesCustomers.region,
            postalCode = saveSalesCustomers.postalCode,
            country = saveSalesCustomers.country,
            phone = saveSalesCustomers.phone,
            fax = saveSalesCustomers.fax
        };
        this.context.SalesCustomers.Add(salesCustomers);
        this.context.SaveChanges();
    }

    public void UpdateSalesCustomers(UpdatesalesCustomersModel updatesalesCustomers)
    {
        SalesCustomers salesCustomersToUpdate = this.context.SalesCustomers.Find(updatesalesCustomers.custId);

        if (salesCustomersToUpdate is null)
        {
            throw new SalesCustomersException("El cliente no esta registrado");
        }
            salesCustomersToUpdate.companyName = updatesalesCustomers.companyName;
            salesCustomersToUpdate.contactName = updatesalesCustomers.contactName;
            salesCustomersToUpdate.contactTtitle = updatesalesCustomers.contactTitle;
            salesCustomersToUpdate.addess = updatesalesCustomers.address;
            salesCustomersToUpdate.email = updatesalesCustomers.email;
            salesCustomersToUpdate.city = updatesalesCustomers.city;
            salesCustomersToUpdate.region = updatesalesCustomers.region;
            salesCustomersToUpdate.postalCode = updatesalesCustomers.postalCode;
            salesCustomersToUpdate.country = updatesalesCustomers.country;
            salesCustomersToUpdate.phone = updatesalesCustomers.phone;
            salesCustomersToUpdate.fax = updatesalesCustomers.fax;

        this.context.SalesCustomers.Update(salesCustomersToUpdate);
        this.context.SaveChanges();
    }
}