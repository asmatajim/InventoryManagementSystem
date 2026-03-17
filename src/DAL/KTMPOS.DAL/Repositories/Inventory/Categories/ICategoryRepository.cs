using KTMPOS.DAL.Entities.Inventory;

namespace KTMPOS.DAL.Repositories.Inventory.Categories
{
    public interface ICategoryRepository
    {
        #region Read

        Task<List<Category>> GetAllAsync();

        Task<List<Category>> FetchAllAsync();

        Task<Category> GetByIdAsync(int id);

        #endregion Read

        #region Write

        Task SaveAsync(Category entity);

        Task UpdateAsync(Category entity);

        Task DeleteAsync(int id);

        #endregion Write
    }
}