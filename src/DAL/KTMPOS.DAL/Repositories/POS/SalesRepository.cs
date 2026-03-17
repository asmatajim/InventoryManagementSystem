using KTMPOS.DAL.Data;
using KTMPOS.DAL.Entities.POS;

namespace KTMPOS.DAL.Repositories.POS
{
    public class SalesRepository : ISalesRepository
    {
        private readonly ApplicationDbContext _context;

        public SalesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(Sales entity)
        {
            await _context
                  .Sales
                  .AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}