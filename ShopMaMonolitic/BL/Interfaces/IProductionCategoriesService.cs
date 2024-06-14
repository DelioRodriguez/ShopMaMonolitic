using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.BL.Interfaces;

public interface IProductionCategoriesService
{
    
    List<ProductionCategoriesModel> GetCategories();
}