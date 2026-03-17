using KTMPOS.DAL.Entities.PurchaseBilling;

namespace KTMPOS.DAL.Repositories.PurchaseBilling
{
    public interface ISupplierRepository
    {
        #region Read

        Task<List<Supplier>> GetAllAsync();

        Task<List<Supplier>> FetchAllAsync();

        Task<Supplier> GetByIdAsync(int id);

        #endregion Read

        #region Write

        Task SaveAsync(Supplier entity);

        Task UpdateAsync(Supplier entity);

        Task DeleteAsync(int id);

        #endregion Write
    }
}