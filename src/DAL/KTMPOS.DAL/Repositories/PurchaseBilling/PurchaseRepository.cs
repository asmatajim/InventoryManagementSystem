using KTMPOS.DAL.Data;
using KTMPOS.DAL.Entities.PurchaseBilling;

namespace KTMPOS.DAL.Repositories.PurchaseBilling
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(Purchase entity)
        {
            await _context
                  .Purchases
                  .AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}