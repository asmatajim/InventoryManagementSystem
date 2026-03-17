using KTMPOS.Common.Enumerations;
using KTMPOS.DAL.Entities.Inventory;

namespace KTMPOS.DAL.Repositories.Inventory.Products
{
    public interface IProductRepository
    {
        #region Read

        Task<List<Product>> GetAllAsync();

        Task<List<Product>> FetchAllAsync();

        Task<Product> GetByIdAsync(int id);

        Task<List<Product>> GetByIdAsync(List<int> ids);

        #endregion Read

        #region Write

        Task SaveAsync(Product entity);

        Task UpdateAsync(Product entity);

        Task UpdateStockAsync(List<Product> entities, BillingType billingType = BillingType.Purchase);

        Task DeleteAsync(int id);

        #endregion Write
    }
}