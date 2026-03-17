using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.Inventory.Products;

namespace KTMPOS.BAL.Services.Inventory.Products
{
    public interface IProductService
    {
        #region Read

        Task<Output<ProductRead>> GetAllAsync();

        Task<Output<Dropdown>> FetchAllAsync();

        Task<Output<ProductDetail>> GetByIdAsync(int id);

        #endregion Read

        #region Write

        Task<Output> SaveAsync(ProductCreate request);

        Task<Output> UpdateAsync(ProductUpdate request);

        Task<Output> DeleteAsync(int id);

        #endregion Write
    }
}