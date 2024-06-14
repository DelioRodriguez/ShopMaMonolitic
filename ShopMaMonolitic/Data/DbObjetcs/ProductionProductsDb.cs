using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Models;
using System.Data.SqlTypes;

namespace DefaultNamespace;

public class ProductionProductsDb : IProductionProducts


{

    private readonly ShopContext context;

    public ProductionProductsDb(ShopContext context)
    {
        this.context = context;
    }

    public ShopContext Context => context;

    private ProductionProductsModel MapToModel(Products products)
    {
        return new ProductionProductsModel
        {
            ProductName = products.productName,
            UnitPrice = products.unitPrice,
            Discontinued = products.discontinued,
            CreationDate = products.creation_date,
            CreatorUser = products.creation_user
        };

    }

    private Products GetProductsByID(int productID)
    {
        var product = this.Context.Products.Find(productID);
        if (product == null)
        {
            throw new NotImplementedException("Este producto no se encuentra");
        }
        return product;
    }
    public ProductionProductsModel GetProducts(int productsID)
    {
        var product = GetProductsByID(productsID);
        return MapToModel(product);
    }




    public List<ProductionProductsModel> GetProducts()
    {
        return this.Context.Products.Select(cc => MapToModel(cc)).ToList();
    }



    public void RemoveProducts(ProductionProductsRemoveModel productsRemove)
    {
        var productToRemove = GetProductsByID(productsRemove.ProductID);
        UpdateDeletedFields(productToRemove, productsRemove.Deleted, productsRemove.DeletedDate, productsRemove.DeletedUser);
        this.Context.Products.Remove(productToRemove);
        this.Context.SaveChanges();
    }

    public void SaveProducts(ProductionProductsAddModel productsAdd)
    {
        var product = new Products
        {
            productName = productsAdd.ProductName,
            creation_date = productsAdd.CreationDate,
            creation_user = productsAdd.CreatorUser,
            unitPrice = productsAdd.UnitPrice,
            discontinued = productsAdd.Discontinued,
        };
    }

    public void UpdateProducts(ProductionProductsUpdateModel productsUpdate)
    {
        var productToUpdate = GetProductsByID(productsUpdate.ProductID);
        UpdateProductsFields(productToUpdate, productsUpdate.ProductName, productsUpdate.ModifyDate, productsUpdate.ModifyUser, productsUpdate.CreationDate, productsUpdate.UnitPrice, productsUpdate.Discontinued);
    }

    private void UpdateProductsFields(Products products, string productName, DateTime modifyDate, int modifyUser, DateTime creationDate, decimal unitPrice, bool discontinued)
    {
        products.productName = productName;
        products.modify_date = modifyDate;
        products.modify_user = modifyUser;
        products.creation_date = creationDate;
        products.unitPrice = unitPrice;
        products.discontinued = discontinued;
    }

    private void UpdateDeletedFields(Products products, bool deleted, DateTime deleteDate, int deleteUser)
    {
        products.deleted = deleted;
        products.delete_date = deleteDate;
        products.delete_user = deleteUser;
    }

   
}