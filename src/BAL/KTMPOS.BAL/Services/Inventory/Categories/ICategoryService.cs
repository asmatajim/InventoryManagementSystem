using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.Inventory.Categories;

namespace KTMPOS.BAL.Services.Inventory.Categories
{
    public interface ICategoryService
    {
        #region Read

        Task<Output<CategoryRead>> GetAllAsync();

        Task<Output<Dropdown>> FetchAllAsync();

        Task<Output<CategoryDetail>> GetByIdAsync(int id);

        #endregion Read

        #region Write

        Task<Output> SaveAsync(CategoryCreate request);

        Task<Output> UpdateAsync(CategoryUpdate request);

        Task<Output> DeleteAsync(int id);

        #endregion Write
    }
}