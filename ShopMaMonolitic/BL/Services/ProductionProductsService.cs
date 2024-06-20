using ShopMaMonolitic.BL.Interfaces;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.BL.Services;

public class ProductionProductsService : IProductionProductsService
{
    private readonly IProductionProductsDb productionProducts;

    public ProductionProductsService(IProductionProductsDb productionProducts)
    {
        this.productionProducts = productionProducts;
    }
    public List<ProductionProductsModel> GetProducts()
    {
        return this.productionProducts.GetProducts();
    }
}