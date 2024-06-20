using ShopMaMonolitic.BL.Exceptions;
using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Data.DbObjetcs
{
    public class ProductionCategoriesDb : IProductionCategoriesDb
    {
        private readonly ShopContext context;

        public ProductionCategoriesDb(ShopContext context)
        {
            this.context = context;
        }

        private ProductionCategories ValidateCategoryExists(int categoryId)
        {
            var category = context.ProductionCategories.Find(categoryId);
            if (category == null)
            {
                throw new ProductionCategoriesServiceException("Esta Categoria no se encuentra");
            }
            return category;
        }

        private static ProductionCategoriesModel MapToModel(ProductionCategories category)
        {
            return new ProductionCategoriesModel
            {
                CategoryId = category.categoryID,
                CategoryName = category.CategoryName,
                Description = category.description,
                CreateDate = category.creation_date,
                CreaterUser = category.creation_user,
                modify_user = category.modify_user,
                modify_date = category.modify_date,
            };
        }

        private ProductionCategories MapToEntity(ProductionCategorieAddModel model)
        {
            ProductionCategories entity = new ProductionCategories();
            entity.CategoryName = model.CategoryName;
            entity.description = model.Description;
            entity.creation_user = model.CreatorUser;
            entity.creation_date = model.CreationDate;
            return entity;
        }

        private void MapToEntity(ProductionCategoriesUpdateModel model, ProductionCategories entity)
        {
            entity.CategoryName = model.CategoryName;
            entity.description = model.Description;
            entity.modify_date = model.UpdatedDate;
            entity.modify_user = model.ModifyUser;
            entity.creation_date = model.CreatedDate;
        }

        public List<ProductionCategoriesModel> GetProductionCategories()
        {
            return context.ProductionCategories.Select(category => MapToModel(category)).ToList();
        }

        public ProductionCategoriesModel GetProductionCategories(int categoryId)
        {
            var category = ValidateCategoryExists(categoryId);
            return MapToModel(category);
        }

        public void RemoveProductionCategories(ProductionCategoriesRemoveModel removeCategories)
        {
            var category = ValidateCategoryExists(removeCategories.CategoryId);
            this.context.ProductionCategories.Remove(category);
            this.context.SaveChanges();
        }

        public void SaveProductionCategories(ProductionCategorieAddModel saveCategories)
        {
            if (saveCategories == null)
            {
                throw new ProductionCategoriesServiceException("");
            }

            var category = MapToEntity(saveCategories);
            context.ProductionCategories.Add(category);
            context.SaveChanges();
        }

        public void UpdateProductionCategories(ProductionCategoriesUpdateModel updateCategories)
        {
            var category = ValidateCategoryExists(updateCategories.CategoryId);

            if (updateCategories == null)
            {
                throw new ProductionCategoriesServiceException("Category no exist");
            }

            MapToEntity(updateCategories, category);
            context.ProductionCategories.Update(category);
            context.SaveChanges();
        }

        private void UpdateDeletedFields(ProductionCategories category, bool deleted, DateTime deleteDate, int deleteUser)
        {
            category.deleted = deleted;
            category.delete_date = deleteDate;
            category.delete_user = deleteUser;
            this.context.SaveChanges();
        }

        
    }
}
