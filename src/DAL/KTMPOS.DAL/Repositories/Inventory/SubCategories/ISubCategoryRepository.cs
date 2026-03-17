using KTMPOS.DAL.Entities.Inventory;

namespace KTMPOS.DAL.Repositories.Inventory.SubCategories
{
    public interface ISubCategoryRepository
    {
        #region Read

        Task<List<SubCategory>> GetAllAsync();

        Task<List<SubCategory>> FetchByCategoryIdAsync(int categoryId);

        Task<SubCategory> GetByIdAsync(int id);

        #endregion Read

        #region Write

        Task SaveAsync(SubCategory entity);

        Task UpdateAsync(SubCategory entity);

        Task DeleteAsync(int id);

        #endregion Write
    }
}