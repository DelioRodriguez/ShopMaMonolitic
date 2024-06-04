using ShopMaMonolitic.Data.Models;

namespace DefaultNamespace;

public interface ISuppliers
{
    List<SuppliersModel> GetSuppliers();
    SuppliersModel GetSuppliers(int SuppliersID);
    void SaveSuppliers(SuppliersAddModel suppliersAdd);
    void UpdateSuppliers(SuppliersUpdateModel suppliersUpdate);
    void RemoveSuppliers(SuppliersRemoveModel suppliersRemove);
    
}