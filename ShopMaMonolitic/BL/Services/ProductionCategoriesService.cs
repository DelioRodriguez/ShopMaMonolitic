
using ShopMaMonolitic.BL.Core;
using ShopMaMonolitic.BL.Interfaces;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.BL.Services;

public class ProductionCategoriesService : IProductionCategoriesService
{
    private readonly IProductionCategoriesDb categories;
    private readonly ILogger<ProductionCategoriesService> logger;

    public ProductionCategoriesService(IProductionCategoriesDb categories, ILogger<ProductionCategoriesService> logger)
    {
        this.logger = logger;
        this.categories = categories;
    }

    public ServicesResult GetCategories()
    {
        ServicesResult result = new ServicesResult();
        try
        {
            result.Data = categories.GetProductionCategories();
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Ocurrio un error obteniendo las categorias";
            this.logger.LogError(ex, result.Message);
        }
        return result;
    }

    public ServicesResult GetCategory(int id)
    {
        ServicesResult result = new ServicesResult();
        try
        {
            result.Data = categories.GetProductionCategories(id);
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Ocurrio un error obteniendo las categorias";
            this.logger.LogError(ex, result.Message);
        }
        return result;
    }

    public ServicesResult RemoveCategories(ProductionCategoriesRemoveModel categoriesRemove)
    {
        ServicesResult result = new ServicesResult();
        try
        {
            if(categoriesRemove is null)
            {
                result.Success = false;
                result.Message = "No puede ser null";
                return result;
            }
            this.categories.RemoveProductionCategories(categoriesRemove);
           
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Ocurrio un error removiendo los datos";
            this.logger.LogError(ex, result.Message);
        }
        return result;
    }

    public ServicesResult SaveCategories(ProductionCategorieAddModel categoriesAdd)
    {
        ServicesResult result = new ServicesResult();
        try
        {
            var validation = ValidateCategory(categoriesAdd);
            if (!validation.Success)
            {
                return validation;
            }
            this.categories.SaveProductionCategories(categoriesAdd);
            result.Success = true;
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Ocurrio un error guardando los datos";
            this.logger.LogError(ex, result.Message);
        }
        return result;
    }

    public ServicesResult UpdateCategories(ProductionCategoriesUpdateModel categoriesUpdate)
    {
        ServicesResult result = new ServicesResult();
        try
        {
            var validation = ValidateCategory(categoriesUpdate);
            if (!validation.Success)
            {
                return validation;
            }
            
            if (categoriesUpdate.CreatedDate == null)
            {
                result.Success = false;
                result.Message = "La fecha de creacion es requerida";
                return result;
            }
            if (categoriesUpdate.ModifyUser == null || categoriesUpdate.ModifyUser == 0)
            {
                result.Success = false;
                result.Message = "El usuario no puede ser 0 o null";
                return result;
            }
            this.categories.UpdateProductionCategories(categoriesUpdate);
            result.Success = true;
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Ocurrio un error actualizando los datos";
            this.logger.LogError(ex, result.Message);
        }
        return result;
    }

    private ServicesResult ValidateCategory(ProductionCategoriesModel category)
    {
        var result = new ServicesResult();
        if (category == null)
        {
            result.Success = false;
            result.Message = "La categoria no puede ser nula";
            return result;
        }
        if (string.IsNullOrEmpty(category.CategoryName))
        {
            result.Success = false;
            result.Message = "El nombre de la categoria es requerido";
            return result;
        }
        if (category.CategoryName.Length > 15)
        {
            result.Success = false;
            result.Message = "La longitud del nombre de la categoria debe de ser 15 caracteres como maximo";
            return result;
        }
        if (string.IsNullOrEmpty(category.Description))
        {
            result.Success = false;
            result.Message = "La descripcion de la categoria es requerida";
            return result;
        }
        if (category.Description.Length > 200)
        {
            result.Success = false;
            result.Message = "La longitud de la descripcion de la categoria debe de ser 200 caracteres como maximo";
            return result;
        }
        result.Success = true;
        return result;
    }
}
