using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Data.DbObjects
{
    public class ProductionCategoriesDb : IProductionCategoriesDb
    {
        private readonly ShopContext context;

        public ProductionCategoriesDb(ShopContext context)
        {
            this.context = context;
        }

        public ShopContext Context => context;

        private static ProductionCategoriesModel MapToModel(ProductionCategories category)
        {
            return new ProductionCategoriesModel
            {
                CategoryId = category.categoryID,
                CategoryName = category.CategoryName,
                Description = category.description,
                CreateDate = category.creation_date,
                CreaterUser = category.creation_user
            };
        }

        private ProductionCategories GetCategoryById(int categoryId)
        {
            var category = this.Context.ProductionCategories.Find(categoryId);
            if (category == null)
            {
                throw new NotImplementedException("Esta Categoria no se encuentra");
            }
            return category;
        }

        public List<ProductionCategoriesModel> GetProductionCategories()
        {
            return this.Context.ProductionCategories.Select(cc => MapToModel(cc)).ToList();
        }

        public ProductionCategoriesModel GetProductionCategories(int categoryId)
        {
            var category = GetCategoryById(categoryId);
            return MapToModel(category);
        }

        public void RemoveProductionCategories(ProductionCategoriesRemoveModel categoriesRemove)
        {
            var categoryToRemove = GetCategoryById(categoriesRemove.CategoryId);
            UpdateDeletedFields(categoryToRemove, categoriesRemove.Deleted, categoriesRemove.DeleteDate, categoriesRemove.DeleteUser);

            this.Context.ProductionCategories.Remove(categoryToRemove);
            this.Context.SaveChanges();
        }

       

        public void SaveProductionCategories(ProductionCategorieAddModel categoriesAdd)
        {
            var category = new ProductionCategories
            { 
                CategoryName = categoriesAdd.CategoryName,
                description = categoriesAdd.Description,
                creation_user = categoriesAdd.CreatorUser,
                creation_date = categoriesAdd.CreationDate
            };

            this.Context.ProductionCategories.Add(category);
            this.Context.SaveChanges();
        }

        public void UpdateProductionCategories(ProductionCategoriesUpdateModel categoriesUpdate)
        {
            var categoryToUpdate = GetCategoryById(categoriesUpdate.CategoryId);
            UpdateCategoryFields(categoryToUpdate, categoriesUpdate.CategoryName, categoriesUpdate.Description, categoriesUpdate.UpdatedDate, categoriesUpdate.ModifyUser, categoriesUpdate.CreatedDate);

            this.Context.SaveChanges();
        }

        private void UpdateDeletedFields(ProductionCategories category, bool deleted, DateTime deleteDate, int deleteUser)
        {
            category.deleted = deleted;
            category.delete_date = deleteDate;
            category.delete_user = deleteUser;
        }

        private void UpdateCategoryFields(ProductionCategories category, string categoryName, string description, DateTime modifyDate, int modifyUser, DateTime createDate)
        {
            

            category.CategoryName = categoryName;
            category.description = description;
            category.modify_date = modifyDate;
            category.modify_user = modifyUser;
            category.creation_date = createDate;
        }
    }
}
