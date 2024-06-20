using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Data.Interfaces
{

    public interface IProductionSuppliersDb
    {
        List<ProductionSuppliersModel> GetSuppliers();
        ProductionSuppliersModel GetSuppliers(int SuppliersID);
        void SaveSuppliers(ProductionSuppliersAddModel suppliersAdd);
        void UpdateSuppliers(ProductionSuppliersUpdateModel suppliersUpdate);
        void RemoveSuppliers(ProductionSuppliersRemoveModel suppliersRemove);

    }
}