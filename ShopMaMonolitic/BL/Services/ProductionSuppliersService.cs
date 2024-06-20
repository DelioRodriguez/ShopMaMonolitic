using DefaultNamespace;
using ShopMaMonolitic.BL.Interfaces;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;
namespace ShopMaMonolitic.BL.Services
{

    public class ProductionSuppliersService : IProductionSuppliersServices
    {
        private readonly IProductionSuppliersDb productionSuppliersDb;

        public ProductionSuppliersService(IProductionSuppliersDb productionSuppliersDb)
        {
            this.productionSuppliersDb = productionSuppliersDb;
        }
        public List<ProductionSuppliersModel>GetSupplier()
        {
            return this.productionSuppliersDb.GetSuppliers();
        }

    }
}