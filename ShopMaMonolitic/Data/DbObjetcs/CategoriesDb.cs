using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Data.DbObjects
{
    public class CategoriesDb : ICategoriesDb
    {
        private readonly ShopContext context;

        public CategoriesDb(ShopContext context)
        {
            this.context = context;
        }

        public ShopContext Context => context;

        private CategoriesModel MapToModel(Categories category)
        {
            return new CategoriesModel
            {
                CategoryName = category.categoryName,
                Description = category.description,
                CreateDate = category.createDate,
                CreaterUser = category.createUser
            };
        }

        private Categories GetCategoryById(int categoryId)
        {
            var category = this.Context.Categories.Find(categoryId);
            if (category == null)
            {
                throw new NotImplementedException("Esta Categoria no se encuentra");
            }
            return category;
        }

        public List<CategoriesModel> GetCategories()
        {
            return this.Context.Categories.Select(cc => MapToModel(cc)).ToList();
        }

        public CategoriesModel GetCategories(int categoryId)
        {
            var category = GetCategoryById(categoryId);
            return MapToModel(category);
        }

        public void RemoveCategories(CategoriesRemoveModel categoriesRemove)
        {
            var categoryToRemove = GetCategoryById(categoriesRemove.CategoryId);
            UpdateDeletedFields(categoryToRemove, categoriesRemove.Deleted, categoriesRemove.DeleteDate, categoriesRemove.DeleteUser);

            this.Context.Categories.Remove(categoryToRemove);
            this.Context.SaveChanges();
        }

       

        public void SaveCategorie(CategorieAddModel categoriesAdd)
        {
            var category = new Categories
            {
                categoryName = categoriesAdd.CategoryName,
                description = categoriesAdd.Description,
                createUser = categoriesAdd.CreatorUser,
                createDate = categoriesAdd.CreationDate
            };

            this.Context.Categories.Add(category);
            this.Context.SaveChanges();
        }

        public void UpdateCategories(CategoriesUpdateModel categoriesUpdate)
        {
            var categoryToUpdate = GetCategoryById(categoriesUpdate.CategoryId);
            UpdateCategoryFields(categoryToUpdate, categoriesUpdate.CategoryName, categoriesUpdate.Description, categoriesUpdate.UpdatedDate, categoriesUpdate.ModifyUser, categoriesUpdate.CreatedDate);

            this.Context.SaveChanges();
        }

        private void UpdateDeletedFields(Categories category, bool deleted, DateTime deleteDate, int deleteUser)
        {
            category.deleted = deleted;
            category.deleteDate = deleteDate;
            category.deleteUser = deleteUser;
        }

        private void UpdateCategoryFields(Categories category, string categoryName, string description, DateTime modifyDate, int modifyUser, DateTime createDate)
        {
            

            category.categoryName = categoryName;
            category.description = description;
            category.modifyDate = modifyDate;
            category.modifyUser = modifyUser;
            category.createDate = createDate;
        }
    }
}
