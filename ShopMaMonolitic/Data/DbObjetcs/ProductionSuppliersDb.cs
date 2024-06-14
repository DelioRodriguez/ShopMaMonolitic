using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Models;
using System.Linq;

namespace DefaultNamespace
{
    public class ProductionSuppliersDb : IProductionSuppliers
    {
        private readonly ShopContext context;

        public ProductionSuppliersDb(ShopContext context)
        {
            this.context = context;
        }

        public ShopContext Context => context;

        private ProductionSuppliersModel MapToModel(ProductionSuppliers suppliers)
        {
            return new ProductionSuppliersModel
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
                CreationDate = suppliers.creation_date,
                CreatorUser = suppliers.creation_user,
            };
        }

        private ProductionSuppliers GetSuppliersById(int suppliersId)
        {
            var suppliers = this.Context.ProductionSuppliers.Find(suppliersId);
            if (suppliers is null)
            {
                throw new NotImplementedException("Este Supplier no se encuentra");
            }
            return suppliers;
        }

        public List<ProductionSuppliersModel> GetSuppliers()
        {
            return this.Context.ProductionSuppliers.Select(cc => MapToModel(cc)).ToList();
        }

        public ProductionSuppliersModel GetSuppliers(int SuppliersID)
        {
            var suppliers = GetSuppliersById(SuppliersID);
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
            var suppliers = new ProductionSuppliers
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
                creation_date = suppliersAdd.CreationDate,
                creation_user = suppliersAdd.CreatorUser,
            };

            this.Context.ProductionSuppliers.Add(suppliers);
            this.Context.SaveChanges();
        }

        public void UpdateSuppliers(ProductionSuppliersUpdateModel suppliersUpdate)
        {
            var suppliersToUpdate = GetSuppliersById(suppliersUpdate.SupplierId);
            UpdateSupplierFields(suppliersToUpdate, suppliersUpdate.CompanyName, suppliersUpdate.ContactName, suppliersUpdate.ContactTitle, suppliersUpdate.City, suppliersUpdate.Region, suppliersUpdate.PostalCode, suppliersUpdate.Country, suppliersUpdate.Phone, suppliersUpdate.Fax, suppliersUpdate.ModifyDate, suppliersUpdate.ModifyUser, suppliersToUpdate.creation_date);

            this.Context.SaveChanges();
        }

        private void UpdateDeletedFields(ProductionSuppliers suppliers, bool deleted, DateTime deleteDate, int deleteUser)
        {
            suppliers.deleted = deleted;
            suppliers.delete_date = deleteDate;
            suppliers.delete_user = deleteUser;
        }

        private void UpdateSupplierFields(ProductionSuppliers suppliers, string companyName, string contactName, string contactTitle, string city, string region, string postalCode, string country, string phone, string fax, DateTime modifyDate, int modifyUser, DateTime createDate)
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
            suppliers.modify_date = modifyDate;
            suppliers.modify_user = modifyUser;
            suppliers.creation_date = createDate;
        }
    }
}
