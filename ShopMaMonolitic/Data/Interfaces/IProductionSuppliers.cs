using ShopMaMonolitic.Data.Models;

namespace DefaultNamespace;

public interface IProductionSuppliers
{
    List<ProductionSuppliersModel> GetSuppliers();
    ProductionSuppliersModel GetSuppliers(int SuppliersID);
    void SaveSuppliers(ProductionSuppliersAddModel suppliersAdd);
    void UpdateSuppliers(ProductionSuppliersUpdateModel suppliersUpdate);
    void RemoveSuppliers(ProductionSuppliersRemoveModel suppliersRemove);
    
}