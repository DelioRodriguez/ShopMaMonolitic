using ShopMaMonolitic.BL.Interfaces;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.BL.Services;

public class ProductionCategoriesService : IProductionCategoriesService
{

    private readonly IProductionCategoriesDb categories;

    public ProductionCategoriesService(IProductionCategoriesDb categories)
    {
        this.categories = categories;
    }
    public List<ProductionCategoriesModel> GetCategories()
    {
        return this.categories.GetProductionCategories();
    }

    
}