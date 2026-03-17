using KTMPOS.DAL.Data;
using KTMPOS.DAL.Entities.Inventory;

using Microsoft.EntityFrameworkCore;

namespace KTMPOS.DAL.Repositories.Inventory.SubCategories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public SubCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Read

        public async Task<List<SubCategory>> GetAllAsync()
        {
            var result = await _context
                               .SubCategories
                               .AsNoTracking()
                               .Include(s => s.Category)
                               .Include(s => s.CreatedByUser)
                               .Include(s => s.ModifiedByUser)
                               .OrderByDescending(c => c.Id)
                               .ToListAsync();
            return result;
        }

        public async Task<List<SubCategory>> FetchByCategoryIdAsync(int categoryId)
        {
            var result = await _context
                               .SubCategories
                               .Where(c => c.CategoryId == categoryId)
                               .Select(c => new SubCategory
                               {
                                   Id = c.Id,
                                   Name = c.Name
                               })
                               .AsNoTracking()
                               .OrderBy(c => c.Name)
                               .ToListAsync();
            return result;
        }

        public async Task<SubCategory> GetByIdAsync(int id)
        {
            var result = await _context
                               .SubCategories
                               .AsNoTracking()
                               .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        #endregion Read

        #region Write

        public async Task SaveAsync(SubCategory entity)
        {
            await CheckDuplicateRecordAsync(entity.Name);
            await _context
                  .SubCategories
                  .AddAsync(entity);

            await _context
                  .SaveChangesAsync();
        }

        private async Task CheckDuplicateRecordAsync(string name)
        {
            bool exists = await _context
                                .SubCategories
                                .AnyAsync(s => s.Name == name);
            if(exists)
            {
                throw new Exception($"Sub category {name} already exists.");
            }
        }

        public async Task UpdateAsync(SubCategory entity)
        {
            var existingResult = await _context
                                       .SubCategories
                                       .FirstOrDefaultAsync(s => s.Id == entity.Id);
            if(existingResult.Name != entity.Name)
            {
                await CheckDuplicateRecordAsync(entity.Name);
            }

            if(existingResult is not null)
            {
                existingResult.Name = entity.Name;
                existingResult.CategoryId = entity.CategoryId;
                existingResult.ModifiedBy = entity.ModifiedBy;
                existingResult.ModifiedDate = DateTime.Now;
                await _context
                      .SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var existingResult = await _context
                                       .SubCategories
                                       .FirstOrDefaultAsync(s => s.Id == id);
            if(existingResult is not null)
            {
                _context
                .SubCategories
                .Remove(existingResult);
                await _context
                      .SaveChangesAsync();
            }
        }

        #endregion Write
    }
}