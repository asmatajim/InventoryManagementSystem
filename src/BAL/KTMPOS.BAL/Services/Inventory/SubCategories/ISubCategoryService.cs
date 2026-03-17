using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.Inventory.SubCategories;

namespace KTMPOS.BAL.Services.Inventory.SubCategories
{
    public interface ISubCategoryService
    {
        #region Read

        Task<Output<SubCategoryRead>> GetAllAsync();

        Task<Output<Dropdown>> FetchByCategoryIdAsync(int categoryId);

        Task<Output<SubCategoryDetail>> GetByIdAsync(int id);

        #endregion Read

        #region Write

        Task<Output> SaveAsync(SubCategoryCreate request);

        Task<Output> UpdateAsync(SubCategoryUpdate request);

        Task<Output> DeleteAsync(int id);

        #endregion Write
    }
}