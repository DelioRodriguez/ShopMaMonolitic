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
    private SalesCustomers ValidateCustomerExists(int customerId)
    {
        var customer = this.context.SalesCustomers.Find(customerId);
        if (customer == null)
        {
            throw new SalesCustomersException("El cliente no esta registrado");
        }
        return customer;
    }

    private SalesCustomersModel MapToModel(SalesCustomers entity)
    {
        return new SalesCustomersModel
        {
            CompanyName = entity.CompanyName,
            ContactName = entity.ContactName,
            ContactTitle = entity.ContactTtitle,
            Address = entity.Address,
            Email = entity.Email,
            City = entity.City,
            Region = entity.Region,
            PostalCode = entity.PostalCode,
            Country = entity.Country,
            Phone = entity.Phone,
            Fax = entity.Fax
        };
    }

    private void MapToEntity(SaveSalesCustomersModel model, SalesCustomers entity)
    {
        entity.CompanyName = model.CompanyName;
        entity.ContactName = model.ContactName;
        entity.ContactTtitle = model.ContactTitle;
        entity.Address = model.Address;
        entity.Email = model.Email;
        entity.City = model.City;
        entity.Region = model.Region;
        entity.PostalCode = model.PostalCode;
        entity.Country = model.Country;
        entity.Phone = model.Phone;
        entity.Fax = model.Fax;
    }

     private void MapToEntity(UpdateSalesCustomersModel model, SalesCustomers entity)
    {
        entity.CompanyName = model.CompanyName;
        entity.ContactName = model.ContactName;
        entity.ContactTtitle = model.ContactTitle;
        entity.Address = model.Address;
        entity.Email = model.Email;
        entity.City = model.City;
        entity.Region = model.Region;
        entity.PostalCode = model.PostalCode;
        entity.Country = model.Country;
        entity.Phone = model.Phone;
        entity.Fax = model.Fax;
    }

    public List<SalesCustomersModel> GetSalesCustomers()
    {
        return this.context.SalesCustomers.Select(customer => MapToModel(customer)).ToList();
    }

    public SalesCustomersModel GetSalesCustomers(int SalesId)
    {
        var customer = ValidateCustomerExists(SalesId);
        return MapToModel(customer);
    }

    public void RemoveSalesCustomers(RemoveSalesCustomersModel removeSalesCustomers)
    {
        var customer = ValidateCustomerExists(removeSalesCustomers.CustId);
        this.context.SalesCustomers.Remove(customer);
        this.context.SaveChanges();
    }

    public void SaveSalesCustomers(SaveSalesCustomersModel saveSalesCustomers)
    {
        var customer = new SalesCustomers();
        MapToEntity(saveSalesCustomers, customer);
        this.context.SalesCustomers.Add(customer);
        this.context.SaveChanges();
    }

    public void UpdateSalesCustomers(UpdateSalesCustomersModel updatesalesCustomers)
    {
        var customer = ValidateCustomerExists(updatesalesCustomers.CustId);
        MapToEntity(updatesalesCustomers, customer);
        this.context.SalesCustomers.Update(customer);
        this.context.SaveChanges();
    }
}