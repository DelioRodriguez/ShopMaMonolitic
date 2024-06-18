using ShopMaMonolitic.BL.Exceptions;
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

    private static SalesCustomersModel MapToModel(SalesCustomers entity)
    {
        return new SalesCustomersModel
        {
            CustId = entity.CustId,
            CompanyName = entity.CompanyName,
            ContactName = entity.ContactName,
            ContactTitle = entity.ContactTitle,
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

    private SalesCustomers MapToEntity(SaveSalesCustomersModel model)
    {
        SalesCustomers entity = new SalesCustomers();
        entity.CustId = model.CustId;
        entity.CompanyName = model.CompanyName;
        entity.ContactName = model.ContactName;
        entity.ContactTitle = model.ContactTitle;
        entity.Address = model.Address;
        entity.Email = model.Email;
        entity.City = model.City;
        entity.Region = model.Region;
        entity.PostalCode = model.PostalCode;
        entity.Country = model.Country;
        entity.Phone = model.Phone;
        entity.Fax = model.Fax;
        return entity;
    }
    private void MapToEntity(UpdateSalesCustomersModel model, SalesCustomers entity)
    {
        entity.CompanyName = model.CompanyName;
        entity.ContactName = model.ContactName;
        entity.ContactTitle = model.ContactTitle;
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

    public SalesCustomersModel GetSalesCustomer(int CustId)
    {
        var customer = ValidateCustomerExists(CustId);
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
        if (saveSalesCustomers == null)
        {
            throw new SalesCustomerServicesExeption("");
        }
        if (saveSalesCustomers.Country.Length > 15)
        {
            throw new SalesCustomerServicesExeption("longitud invalida");
        }
        if (saveSalesCustomers.City.Length > 15)
        {
            throw new SalesCustomerServicesExeption("Logitud Invalida");
        }

        var customer = MapToEntity(saveSalesCustomers);
        this.context.SalesCustomers.Add(customer);
        this.context.SaveChanges();
    }

    public void UpdateSalesCustomers(UpdateSalesCustomersModel updatesalesCustomers)
    {
        var customer = ValidateCustomerExists(updatesalesCustomers.CustId);

        if (updatesalesCustomers == null)
        {
            throw new SalesCustomerServicesExeption("Customer no exist");
        }

        //Los casos de usos se mueven a la clase Action results 
        if (updatesalesCustomers.Country.Length > 15)
        {
            throw new SalesCustomerServicesExeption("longitud invalida");
        }
        if (updatesalesCustomers.City.Length > 15)
        {
            throw new SalesCustomerServicesExeption("Logitud Invalida");
        }

        MapToEntity(updatesalesCustomers, customer);
        this.context.SalesCustomers.Update(customer);
        this.context.SaveChanges();
    }
}