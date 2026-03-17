using KTMPOS.DAL.Entities.PurchaseBilling;

namespace KTMPOS.DAL.Repositories.PurchaseBilling
{
    public interface IPurchaseRepository
    {
        Task SaveAsync(Purchase entity);
    }
}