using ShopMaMonolitic.BL.Exceptions;
using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopMaMonolitic.Data.DbObjetcs
{
    public class ProductionSuppliersDb : IProductionSuppliersDb
    {
        private readonly ShopContext context;

        public ProductionSuppliersDb(ShopContext context)
        {
            this.context = context;
        }

        public ShopContext Context => context;

        private ProductionSuppliers GetSuppliersById(int suppliersId)
        {
            var suppliers = this.Context.ProductionSuppliers.Find(suppliersId);
            if (suppliers == null)
            {
                throw new ProductionSuppliersServicesException("Este Supplier no se encuentra");
            }
            return suppliers;
        }

        private static ProductionSuppliersModel MapToModel(ProductionSuppliers suppliers)
        {
            return new ProductionSuppliersModel
            {
                SuppliersID = suppliers.supplierID,
                CompanyName = suppliers.companyName,
                ContactName = suppliers.contactName,
                ContactTitle = suppliers.contactTitle,
                Address = suppliers.address,
                City = suppliers.city,
                Region = suppliers.region,
                PostalCode = suppliers.postalcode,
                Country = suppliers.country,
                Phone = suppliers.phone,
                Fax = suppliers.fax,
                CreationDate = suppliers.creation_date,
                CreatorUser = suppliers.creation_user,
            };
        }

        private ProductionSuppliers MapToEntity(ProductionSuppliersAddModel suppliersAdd)
        {
            return new ProductionSuppliers
            {
                companyName = suppliersAdd.CompanyName,
                contactName = suppliersAdd.ContactName,
                contactTitle = suppliersAdd.ContactTitle,
                address = suppliersAdd.Address,
                city = suppliersAdd.City,
                region = suppliersAdd.Region,
                postalcode = suppliersAdd.PostalCode,
                country = suppliersAdd.Country,
                phone = suppliersAdd.Phone,
                fax = suppliersAdd.Fax,
                creation_date = suppliersAdd.CreationDate,
                creation_user = suppliersAdd.CreatorUser,
            };
        }

        public List<ProductionSuppliersModel> GetSuppliers()
        {
            return this.Context.ProductionSuppliers.Select(suppliers => MapToModel(suppliers)).ToList();
        }

        public ProductionSuppliersModel GetSuppliers(int suppliersId)
        {
            var suppliers = GetSuppliersById(suppliersId);
            return MapToModel(suppliers);
        }

        public void RemoveSuppliers(ProductionSuppliersRemoveModel suppliersRemove)
        {
            var suppliersToRemove = GetSuppliersById(suppliersRemove.SupplierId);
            UpdateDeletedFields(suppliersToRemove, suppliersRemove.Deleted, suppliersRemove.DeleteDate, suppliersRemove.DeletedUser);

            this.Context.ProductionSuppliers.Remove(suppliersToRemove);
            this.Context.SaveChanges();
        }

        public void SaveSuppliers(ProductionSuppliersAddModel suppliersAdd)
        {
            if (suppliersAdd == null)
            {
                throw new ProductionSuppliersServicesException("Datos de Supplier no válidos");
            }

            var suppliers = MapToEntity(suppliersAdd);
            this.Context.ProductionSuppliers.Add(suppliers);
            this.Context.SaveChanges();
        }

        public void UpdateSuppliers(ProductionSuppliersUpdateModel suppliersUpdate)
        {
            var suppliersToUpdate = GetSuppliersById(suppliersUpdate.SupplierId);

            if (suppliersUpdate == null)
            {
                throw new ProductionSuppliersServicesException("Datos de Supplier no válidos para actualizar");
            }

            UpdateSupplierFields(suppliersToUpdate,suppliersToUpdate.address, suppliersUpdate.CompanyName, suppliersUpdate.ContactName, suppliersUpdate.ContactTitle, suppliersUpdate.City, suppliersUpdate.Region, suppliersUpdate.PostalCode, suppliersUpdate.Country, suppliersUpdate.Phone, suppliersUpdate.Fax, suppliersUpdate.ModifyDate, suppliersUpdate.ModifyUser, suppliersToUpdate.creation_date);

            this.Context.SaveChanges();
        }

        private void UpdateDeletedFields(ProductionSuppliers suppliers, bool deleted, DateTime deleteDate, int deleteUser)
        {
            suppliers.deleted = deleted;
            suppliers.delete_date = deleteDate;
            suppliers.delete_user = deleteUser;
        }

        private void UpdateSupplierFields(ProductionSuppliers suppliers,string address, string companyName, string contactName, string contactTitle, string city, string region, string postalCode, string country, string phone, string fax, DateTime modifyDate, int modifyUser, DateTime createDate)
        {
            suppliers.companyName = companyName;
            suppliers.contactName = contactName;
            suppliers.contactTitle = contactTitle;
            suppliers.address = address;
            suppliers.city = city;
            suppliers.region = region;
            suppliers.postalcode = postalCode;
            suppliers.country = country;
            suppliers.phone = phone;
            suppliers.fax = fax;
            suppliers.modify_date = modifyDate;
            suppliers.modify_user = modifyUser;
            suppliers.creation_date = createDate;
        }
    }
}
