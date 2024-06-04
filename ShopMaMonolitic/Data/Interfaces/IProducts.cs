using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Models;

namespace DefaultNamespace;

public interface IProducts
{
    ShopContext Context { get; }

    List<ProductsModel> GetProducts();
    ProductsModel GetProducts(int productsID);
    void SaveProducts(ProductsAddModel productsAdd);
    void UpdateProducts(ProductsUpdateModel productsUpdate);    
    void RemoveProducts( ProductsRemoveModel productsRemove);
    List<ProductsModel> GetProducts();
    ProductsModel GetProducts(int productsID);
    ProductsModel MapToModel(Products products);
    void RemoveProducts(ProductsRemoveModel productsRemove);
    void SaveProducts(ProductsAddModel productsAdd);
    void UpdateProducts(ProductsUpdateModel productsUpdate);
}