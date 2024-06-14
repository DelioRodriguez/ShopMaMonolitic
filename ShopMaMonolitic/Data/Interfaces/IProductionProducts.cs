using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Models;

namespace DefaultNamespace;

public interface IProductionProducts
{
    ShopContext Context { get; }

    List<ProductionProductsModel> GetProducts();
    ProductionProductsModel GetProducts(int productsID);
    void SaveProducts(ProductionProductsAddModel productsAdd);
    void UpdateProducts(ProductionProductsUpdateModel productsUpdate);    
    void RemoveProducts( ProductionProductsRemoveModel productsRemove);
    
}