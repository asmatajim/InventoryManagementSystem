using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.PurchaseBilling;

namespace KTMPOS.BAL.Services.PurchaseBilling
{
    public interface ISupplierService
    {
        #region Read

        Task<Output<SupplierRead>> GetAllAsync();

        Task<Output<Dropdown>> FetchAllAsync();

        Task<Output<SupplierDetail>> GetByIdAsync(int id);

        #endregion Read

        #region Write

        Task<Output> SaveAsync(SupplierCreate request);

        Task<Output> UpdateAsync(SupplierUpdate request);

        Task<Output> DeleteAsync(int id);

        #endregion Write
    }
}