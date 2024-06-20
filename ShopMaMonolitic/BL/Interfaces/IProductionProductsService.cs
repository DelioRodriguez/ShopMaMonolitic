using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.BL.Interfaces;


public interface IProductionProductsService
{
    List<ProductionProductsModel> GetProducts();
    
}