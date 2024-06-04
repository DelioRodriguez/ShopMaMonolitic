using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Data.Interfaces;

public interface ICategoriesDb
{
    List<CategoriesModel> GetCategories();
    CategoriesModel GetCategories(int categorieID);
    void SaveCategorie(CategorieAddModel categoriesAdd);
    void UpdateCategories(CategoriesUpdateModel categoriesUpdate);
    void RemoveCategories(CategoriesRemoveModel categoriesRemove);
    
}