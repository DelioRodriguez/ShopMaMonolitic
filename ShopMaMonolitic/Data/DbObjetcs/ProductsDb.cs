using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Models;
using System.Data.SqlTypes;

namespace DefaultNamespace;

public class ProductsDb : IProducts


{

    private readonly ShopContext context;

    public ProductsDb(ShopContext context)
    {
        this.context = context;
    }

    public ShopContext Context => context;

    private ProductsModel MapToModel(Products products)
    {
        return new ProductsModel
        {
            ProductName = products.productName,
            UnitPrice = products.unitPrice,
            Discontinued = products.discontinued,
            CreationDate = products.createDate,
            CreatorUser = products.createUser
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
    public ProductsModel GetProducts(int productsID)
    {
        var product = GetProductsByID(productsID);
        return MapToModel(product);
    }




    public List<ProductsModel> GetProducts()
    {
        return this.Context.Products.Select(cc => MapToModel(cc)).ToList();
    }



    public void RemoveProducts(ProductsRemoveModel productsRemove)
    {
        var productToRemove = GetProductsByID(productsRemove.ProductID);
        UpdateDeletedFields(productToRemove, productsRemove.Deleted, productsRemove.DeletedDate, productsRemove.DeletedUser);
        this.Context.Products.Remove(productToRemove);
        this.Context.SaveChanges();
    }

    public void SaveProducts(ProductsAddModel productsAdd)
    {
        var product = new Products
        {
            productName = productsAdd.ProductName,
            createDate = productsAdd.CreationDate,
            createUser = productsAdd.CreatorUser,
            unitPrice = productsAdd.UnitPrice,
            discontinued = productsAdd.Discontinued,
        };
    }

    public void UpdateProducts(ProductsUpdateModel productsUpdate)
    {
        var productToUpdate = GetProductsByID(productsUpdate.ProductID);
        UpdateProductsFields(productToUpdate, productsUpdate.ProductName, productsUpdate.ModifyDate, productsUpdate.ModifyUser, productsUpdate.CreationDate, productsUpdate.UnitPrice, productsUpdate.Discontinued);
    }

    private void UpdateProductsFields(Products products, string productName, DateTime modifyDate, int modifyUser, DateTime creationDate, SqlMoney unitPrice, bool discontinued)
    {
        products.productName = productName;
        products.modifyDate = modifyDate;
        products.modifyUser = modifyUser;
        products.createDate = creationDate;
        products.unitPrice = unitPrice;
        products.discontinued = discontinued;
    }

    private void UpdateDeletedFields(Products products, bool deleted, DateTime deleteDate, int deleteUser)
    {
        products.deleted = deleted;
        products.deleteDate = deleteDate;
        products.deleteUser = deleteUser;
    }

   
}