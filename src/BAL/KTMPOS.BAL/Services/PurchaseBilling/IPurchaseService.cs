using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.PurchaseBilling;

namespace KTMPOS.BAL.Services.PurchaseBilling
{
    public interface IPurchaseService
    {
        Task<Output> SaveAsync(PurchaseCreate request);
    }
}