using KTMPOS.Common.Enumerations;
using KTMPOS.DAL.Data;
using KTMPOS.DAL.Entities.Inventory;

using Microsoft.EntityFrameworkCore;

namespace KTMPOS.DAL.Repositories.Inventory.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) => _context = context;

        #region Read

        public async Task<List<Product>> GetAllAsync()
        {
            List<Product> result = await _context
                                         .Products
                                         .AsNoTracking()
                                         .Include(x => x.SubCategory)
                                         .ThenInclude(x => x.Category)
                                         .Include(x => x.CreatedByUser)
                                         .Include(x => x.ModifiedByUser)
                                         .OrderByDescending(x => x.Id)
                                         .ToListAsync();

            return result;
        }

        public async Task<List<Product>> FetchAllAsync()
        {
            List<Product> result = await _context
                                         .Products
                                         .AsNoTracking()
                                         .Select(x => new Product
                                         {
                                             Id = x.Id,
                                             Name = x.Name,
                                         })
                                         .OrderBy(x => x.Name)
                                         .ToListAsync();

            return result;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var result = await _context
                               .Products
                               .AsNoTracking()
                               .Include(x => x.SubCategory)
                               .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<List<Product>> GetByIdAsync(List<int> ids)
        {
            // 1 query per id (worst approach, very slow)
            //List<Product> products = [];
            //foreach(var id in ids)
            //{
            //    var result = await _context
            //                   .Products
            //                   .AsNoTracking()
            //                   .Include(x => x.SubCategory)
            //                   .FirstOrDefaultAsync(x => x.Id == id);
            //    products.Add(result);
            //}

            //return products;

            // 2 query for all ids (better approach, fast)
            var result = await _context
                               .Products
                               .AsNoTracking()
                               .Include(x => x.SubCategory)
                               .Where(x => ids.Contains(x.Id))
                               .ToListAsync();
            return result;
        }

        #endregion Read

        #region Write

        public async Task SaveAsync(Product entity)
        {
            await CheckDuplicateRecordAsync(entity.Name);
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        private async Task CheckDuplicateRecordAsync(string name)
        {
            bool isExists = await _context
                                  .Products
                                  .AnyAsync(x => x.Name.ToLower() == name.ToLower());
            if(isExists)
            {
                throw new Exception($"Product with name {name} already exists.");
            }
        }

        public async Task UpdateAsync(Product entity)
        {
            var existingRecord = await GetExistingRecordAsync(entity.Id);
            if(existingRecord.Name != entity.Name)
            {
                await CheckDuplicateRecordAsync(entity.Name);
            }

            existingRecord.Name = entity.Name;
            existingRecord.SubCategoryId = entity.SubCategoryId;
            existingRecord.PurchasePrice = entity.PurchasePrice;
            existingRecord.SellingPrice = entity.SellingPrice;
            existingRecord.ModifiedBy = entity.ModifiedBy;
            existingRecord.ModifiedDate = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStockAsync(List<Product> entities, BillingType billingType = BillingType.Purchase)
        {
            List<int> ids = entities
                            .Select(x => x.Id)
                            .ToList();
            var existingRecords = await _context
                                        .Products
                                        .Where(x => ids.Contains(x.Id))
                                        .ToListAsync();

            DateTime now = DateTime.Now;
            int? modifiedBy = entities
                              .Select(x => x.ModifiedBy)
                              .FirstOrDefault();
            foreach(Product record in existingRecords)
            {
                int stock = entities
                            .Where(x => x.Id == record.Id)
                            .Select(x => x.Stock)
                            .FirstOrDefault();
                if(billingType == BillingType.Purchase)
                {
                    record.Stock += stock;
                }
                else
                {
                    record.Stock -= stock;
                }

                record.ModifiedBy = modifiedBy;
                record.ModifiedDate = now;
            }

            await _context.SaveChangesAsync();
        }

        private async Task<Product> GetExistingRecordAsync(int id)
        {
            var existingRecord = await _context
                                       .Products
                                       .FirstOrDefaultAsync(x => x.Id == id);
            if(existingRecord == null)
                throw new Exception($"Product with id {id} not found.");

            return existingRecord;
        }

        public async Task DeleteAsync(int id)
        {
            var existingRecord = await GetExistingRecordAsync(id);
            _context.Products.Remove(existingRecord);
            await _context.SaveChangesAsync();
        }

        #endregion Write
    }
}