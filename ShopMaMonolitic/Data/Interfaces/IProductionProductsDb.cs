using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Data.Interfaces;

public interface IProductionProductsDb
{
   

    List<ProductionProductsModel> GetProducts();
    ProductionProductsModel GetProduct(int productsID);
    void SaveProducts(ProductionProductsAddModel productsAdd);
    void UpdateProducts(ProductionProductsUpdateModel productsUpdate);    
    void RemoveProducts( ProductionProductsRemoveModel productsRemove);
    
}