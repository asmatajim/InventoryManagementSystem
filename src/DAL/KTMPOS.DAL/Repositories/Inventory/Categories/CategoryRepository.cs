using KTMPOS.DAL.Data;
using KTMPOS.DAL.Entities.Inventory;

using Microsoft.EntityFrameworkCore;

namespace KTMPOS.DAL.Repositories.Inventory.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Read

        public async Task<List<Category>> GetAllAsync()
        {
            var result = await _context
                               .Categories
                               .AsNoTracking()
                               .Include(s => s.CreatedByUser)
                               .Include(s => s.ModifiedByUser)
                               .OrderByDescending(c => c.Id)
                               .ToListAsync();
            return result;
        }

        public async Task<List<Category>> FetchAllAsync()
        {
            var result = await _context
                               .Categories
                               .Select(c => new Category
                               {
                                   Id = c.Id,
                                   Name = c.Name
                               })
                               .AsNoTracking()
                               .OrderBy(c => c.Name)
                               .ToListAsync();
            return result;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var result = await _context
                               .Categories
                               .AsNoTracking()
                               .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        #endregion Read

        #region Write

        public async Task SaveAsync(Category entity)
        {
            await CheckDuplicateRecordAsync(entity.Name);
            await _context
                  .Categories
                  .AddAsync(entity);

            await _context
                  .SaveChangesAsync();
        }

        private async Task CheckDuplicateRecordAsync(string name)
        {
            bool exists = await _context
                                .Categories
                                .AnyAsync(s => s.Name == name);
            if(exists)
            {
                throw new Exception($"Category {name} already exists.");
            }
        }

        public async Task UpdateAsync(Category entity)
        {
            var existingResult = await _context
                                       .Categories
                                       .FirstOrDefaultAsync(s => s.Id == entity.Id);
            if(existingResult.Name != entity.Name)
            {
                await CheckDuplicateRecordAsync(entity.Name);
            }

            if(existingResult is not null)
            {
                existingResult.Name = entity.Name;
                existingResult.ModifiedBy = entity.ModifiedBy;
                existingResult.ModifiedDate = DateTime.Now;
                await _context
                      .SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var existingResult = await _context
                                       .Categories
                                       .FirstOrDefaultAsync(s => s.Id == id);
            if(existingResult is not null)
            {
                _context
                .Categories
                .Remove(existingResult);
                await _context
                      .SaveChangesAsync();
            }
        }

        #endregion Write
    }
}