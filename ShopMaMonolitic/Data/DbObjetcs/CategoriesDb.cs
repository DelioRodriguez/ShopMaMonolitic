using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Data.DbObjetcs;

public class CategoriesDb : ICategoriesDb
{
    private readonly ShopContext context;

    public CategoriesDb (ShopContext context)
    {
        this.context = context;
    }

    public List<CategoriesModel> GetCategories()
    {
        return this.context.Categories.Select(cc => new CategoriesModel()
        {
            CategoryName = cc.categoryName,
            Description = cc.description,
            CreateDate = cc.createDate, 
            CreaterUser = cc.createUser
        }).ToList();
        
    }

    public CategoriesModel GetCategories(int categorieID)
    {

        var categories = this.context.Categories.Find(categorieID);
        if (categories is null)
        {
            throw new NotImplementedException("Esta Categoria no se encuentra ");
        }
        CategoriesModel categoriesModel = new CategoriesModel()
        {
            CategoryName = categories.categoryName,
            Description = categories.description,
            CreaterUser = categories.createUser,
            CreateDate = categories.createDate
        };

        return categoriesModel;
       
    }

    public void RemoveCategories(CategoriesRemoveModel categoriesRemove)
    {
        var categoryToRemove = this.context.Categories.Find(categoriesRemove.CategoryId);
        if (categoryToRemove is null)
        {
            throw new NotImplementedException("Esta categoria no se encuentra");
        }
        categoryToRemove.deleted = categoriesRemove.Deleted;
        categoryToRemove.deleteDate = categoriesRemove.DeleteDate;
        categoryToRemove.deleteUser = categoriesRemove.Deleteuser;

        this.context.Categories.Remove(categoryToRemove);
        this.context.SaveChanges();


    }

    public void SaveCategorie(CategorieAddModel categoriesAdd)
    {
        Categories Categories = new Categories()
        {
            categoryName = Categories.categoryName,
            description = Categories.description,
        }
       
    }

    public void UpdateCategories(CategoriesUpdateModel categoriesUpdate)
    {
        throw new NotImplementedException();
    }
}