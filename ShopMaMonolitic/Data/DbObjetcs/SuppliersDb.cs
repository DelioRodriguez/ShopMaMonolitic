using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Models;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace DefaultNamespace;

public class SuppliersDb : ISuppliers

{

    private readonly ShopContext context;

    public SuppliersDb(ShopContext context)
    {

        this.context = context;
    }
    public ShopContext Context => context;

    private SuppliersModel MapToModel(Suppliers suppliers)
    {
        return new SuppliersModel
        {
            CompanyName = suppliers.companyName,
            ContactName = suppliers.contactName,
            ContactTitle = suppliers.contactTitle,
            Address = suppliers.adress,
            City = suppliers.city,
            Region = suppliers.region,
            PostalCode = suppliers.postalcode,
            Country = suppliers.country,
            Phone = suppliers.phone,
            Fax = suppliers.fax,
            CreationDate = suppliers.createDate,
            CreatorUser = suppliers.createUser,
        };

    }
    private Suppliers GetSuppliersById(int suppliersId)
    {
        var suppliers = this.Context.Suppliers.Find(suppliersId);
        if (suppliers is null)
        {
            throw new NotImplementedException("Este Supplier no se encuentra");
        }
        return suppliers;
    }
    public List<SuppliersModel> GetSuppliers()
    {
        return this.Context.Suppliers.Select(cc => MapToModel(cc)).ToList();
    }

    public SuppliersModel GetSuppliers(int SuppliersID)
    {
        var suppliers = GetSuppliersById(SuppliersID);
        return MapToModel(suppliers);
    }

    public void RemoveSuppliers(SuppliersRemoveModel suppliersRemove)
    {
        var suppliersToRemove = GetSuppliersById(suppliersRemove.SupplierId);
        UpdateDeletedFields(suppliersToRemove, suppliersRemove.Deleted, suppliersRemove.DeleteDate, suppliersRemove.DeletedUser);

        this.Context.Suppliers.Remove(suppliersToRemove);
        this.Context.SaveChanges();
    }

    public void SaveSuppliers(SuppliersAddModel suppliersAdd)
    {
        var suppliers = new Suppliers
        {
            companyName = suppliersAdd.CompanyName,
            contactName = suppliersAdd.ContactName,
            contactTitle = suppliersAdd.ContactTitle,
            city = suppliersAdd.City,
            region = suppliersAdd.Region,
            postalcode = suppliersAdd.PostalCode,
            country = suppliersAdd.Country,
            phone = suppliersAdd.Phone,
            fax = suppliersAdd.Fax,
            createDate = suppliersAdd.CreationDate,
            createUser = suppliersAdd.CreatorUser,

        };
    }

    public void UpdateSuppliers(SuppliersUpdateModel suppliersUpdate)
    {
        var suppliersToUpdate = GetSuppliersById(suppliersUpdate.SupplierId);
        UpdateSupplierFields(suppliersToUpdate, suppliersToUpdate.companyName, suppliersToUpdate.contactName, suppliersToUpdate.contactTitle, suppliersToUpdate.city, suppliersToUpdate.region
            , suppliersToUpdate.postalcode, suppliersToUpdate.country, suppliersToUpdate.phone, suppliersToUpdate.fax, suppliersToUpdate.modifyDate, suppliersToUpdate.modifyUser, suppliersToUpdate.createDate);
    }

    private void UpdateDeletedFields(Suppliers suppliers, bool deleted, DateTime deleteDate, int deleteUser)
    {
        suppliers.deleted = deleted;
        suppliers.deleteDate = deleteDate;
        suppliers.deleteUser = deleteUser;
    }

    private void UpdateSupplierFields(Suppliers suppliers, string companyName, string contactName, string contactTitle, string city, string region, string postalCode, string country, string phone, string fax, DateTime modifyDate, int modifyUser, DateTime createDate)
    {
        suppliers.companyName = companyName;
        suppliers.contactName = contactName;
        suppliers.contactTitle = contactTitle;
        suppliers.city = city;
        suppliers.region = region;
        suppliers.postalcode = postalCode;
        suppliers.country = country;
        suppliers.phone = phone;
        suppliers.fax = fax;
        suppliers.modifyDate = modifyDate;
        suppliers.modifyUser = modifyUser;
        suppliers.createDate = createDate;
    }
}
