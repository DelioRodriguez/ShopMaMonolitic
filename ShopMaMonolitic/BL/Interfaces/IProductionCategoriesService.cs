using ShopMaMonolitic.BL.Core;
using ShopMaMonolitic.BL.Dtos;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.BL.Interfaces;

public interface IProductionCategoriesService
{

    ServicesResult GetCategories();
    ServicesResult GetCategory( int id);

    ServicesResult UpdateCategories(ProductionCategoriesUpdateModel categoriesUpdate);

    ServicesResult RemoveCategories(ProductionCategoriesRemoveModel categoriesRemove);

    ServicesResult SaveCategories(ProductionCategorieAddModel cateriesAdd);
}