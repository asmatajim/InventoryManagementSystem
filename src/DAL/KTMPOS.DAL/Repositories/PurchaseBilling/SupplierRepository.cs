using KTMPOS.DAL.Data;
using KTMPOS.DAL.Entities.PurchaseBilling;

using Microsoft.EntityFrameworkCore;

namespace KTMPOS.DAL.Repositories.PurchaseBilling
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Read

        public async Task<List<Supplier>> GetAllAsync()
        {
            var result = await _context
                               .Suppliers
                               .AsNoTracking()
                               .Include(s => s.CreatedByUser)
                               .Include(s => s.ModifiedByUser)
                               .OrderByDescending(c => c.Id)
                               .ToListAsync();
            return result;
        }

        public async Task<List<Supplier>> FetchAllAsync()
        {
            var result = await _context
                               .Suppliers
                               .Select(c => new Supplier
                               {
                                   Id = c.Id,
                                   Name = c.Name
                               })
                               .AsNoTracking()
                               .OrderBy(c => c.Name)
                               .ToListAsync();
            return result;
        }

        public async Task<Supplier> GetByIdAsync(int id)
        {
            var result = await _context
                               .Suppliers
                               .AsNoTracking()
                               .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        #endregion Read

        #region Write

        public async Task SaveAsync(Supplier entity)
        {
            await CheckDuplicatePhoneNumberAsync(entity.PhoneNumber);
            await CheckDuplicateEmailAsync(entity.EmailAddress);
            await _context
                  .Suppliers
                  .AddAsync(entity);

            await _context
                  .SaveChangesAsync();
        }

        private async Task CheckDuplicatePhoneNumberAsync(string phoneNumber)
        {
            bool isExists = await _context
                                  .Suppliers
                                  .AnyAsync(x => x.PhoneNumber == phoneNumber);
            if(isExists)
            {
                throw new Exception($"Supplier with phone {phoneNumber} already exists.");
            }
        }

        private async Task CheckDuplicateEmailAsync(string email)
        {
            bool isExists = await _context
                                  .Suppliers
                                  .AnyAsync(x => x.EmailAddress.ToLower() == email.ToLower());
            if(isExists)
            {
                throw new Exception($"Supplier with email {email} already exists.");
            }
        }

        public async Task UpdateAsync(Supplier entity)
        {
            var existingResult = await _context
                                       .Suppliers
                                       .FirstOrDefaultAsync(s => s.Id == entity.Id);
            if(existingResult.PhoneNumber != entity.PhoneNumber)
            {
                await CheckDuplicatePhoneNumberAsync(entity.PhoneNumber);
            }

            if(existingResult.EmailAddress != entity.EmailAddress)
            {
                await CheckDuplicateEmailAsync(entity.EmailAddress);
            }

            if(existingResult is not null)
            {
                existingResult.Name = entity.Name;
                existingResult.Address = entity.Address;
                existingResult.PhoneNumber = entity.PhoneNumber;
                existingResult.ContactPerson = entity.ContactPerson;
                existingResult.EmailAddress = entity.EmailAddress;
                existingResult.ModifiedBy = entity.ModifiedBy;
                existingResult.ModifiedDate = DateTime.Now;
                await _context
                      .SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var existingResult = await _context
                                       .Suppliers
                                       .FirstOrDefaultAsync(s => s.Id == id);
            if(existingResult is not null)
            {
                _context
                .Suppliers
                .Remove(existingResult);
                await _context
                      .SaveChangesAsync();
            }
        }

        #endregion Write
    }
}