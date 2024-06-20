using ShopMaMonolitic.BL.Exceptions;
using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopMaMonolitic.Data.DbObjects
{
    public class ProductionProductsDb : IProductionProductsDb
    {
        private readonly ShopContext context;

        public ProductionProductsDb(ShopContext context)
        {
            this.context = context;
        }

       

        private static ProductionProductsModel MapToModel(ProductionProducts product)
        {
            return new ProductionProductsModel
            {
                ProductID = product.productID,
                ProductName = product.productName,
                supplierID = product.supplierID,
                categoryID = product.categoryID,
                UnitPrice = product.unitPrice,
                Discontinued = product.discontinued,
                CreationDate = product.creation_date,
                CreatorUser = product.creation_user,
                modify_date = product.modify_date,
                modify_user = product.modify_user
            };
        }

        private ProductionProducts MapToEntity(ProductionProductsAddModel model)
        {
            ProductionProducts entity = new ProductionProducts();
            entity.productName = model.ProductName;
            entity.categoryID = model.categoryID;
            entity.supplierID = model.supplierID;
            entity.unitPrice = model.UnitPrice;
            entity.creation_user = model.CreatorUser;
            entity.creation_date = model.CreationDate;
            entity.discontinued = model.Discontinued;
            return entity;
        }

        private void MapToEntity(ProductionProductsUpdateModel model, ProductionProducts entity)
        {
            entity.productName = model.ProductName;
            entity.categoryID = entity.categoryID;
            entity.supplierID = entity.supplierID;
            entity.modify_date = model.ModifyDate;
            entity.modify_user = model.ModifyUser;
            entity.creation_date = model.CreationDate;
            entity.unitPrice = model.UnitPrice;
            entity.discontinued = model.Discontinued;
        }

        public List<ProductionProductsModel> GetProducts()
        {
            return context.Products.Select(product => MapToModel(product)).ToList();
        }

        public ProductionProductsModel GetProduct(int productId)
        {
            var product = ValidateProductExists(productId);
            return MapToModel(product);
        }
        private ProductionProducts ValidateProductExists(int productId)
        {
            var product = context.Products.Find(productId);
            if (product == null)
            {
                throw new NotImplementedException("El producto no se encuentra");
            }
            return product;
        }
        public void RemoveProducts(ProductionProductsRemoveModel removeProducts)
        {
            var product = ValidateProductExists(removeProducts.ProductID);
            UpdateDeletedFields(product, removeProducts.Deleted, removeProducts.DeletedDate, removeProducts.DeletedUser);
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public void SaveProducts(ProductionProductsAddModel saveProducts)
        {
            if (saveProducts == null)
            {
                throw new ProductionProductsServiceException("El modelo de producto es nulo");
            }

            var product = MapToEntity(saveProducts);
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void UpdateProducts(ProductionProductsUpdateModel updateProducts)
        {
            var product = ValidateProductExists(updateProducts.ProductID);

            if (updateProducts == null)
            {
                throw new ProductionProductsServiceException("El producto no existe");
            }

            MapToEntity(updateProducts, product);
            context.Products.Update(product);
            context.SaveChanges();
        }

        private void UpdateDeletedFields(ProductionProducts product, bool deleted, DateTime deleteDate, int deleteUser)
        {
            product.deleted = deleted;
            product.delete_date = deleteDate;
            product.delete_user = deleteUser;
            context.SaveChanges();
        }
    }
}
