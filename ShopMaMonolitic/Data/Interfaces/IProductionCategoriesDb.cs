using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Data.Interfaces;

public interface IProductionCategoriesDb
{
    List<ProductionCategoriesModel> GetProductionCategories();
    ProductionCategoriesModel GetProductionCategories(int categorieID);
    void SaveProductionCategories(ProductionCategorieAddModel categoriesAdd);
    void UpdateProductionCategories(ProductionCategoriesUpdateModel categoriesUpdate);
    void RemoveProductionCategories(ProductionCategoriesRemoveModel categoriesRemove);
    
}