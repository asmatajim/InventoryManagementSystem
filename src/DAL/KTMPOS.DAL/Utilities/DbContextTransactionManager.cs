using KTMPOS.DAL.Data;

using Microsoft.EntityFrameworkCore.Storage;

namespace KTMPOS.DAL.Utilities
{
    public class DbContextTransactionManager : ITransactionManager
    {
        private readonly ApplicationDbContext _dbContext;

        public DbContextTransactionManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }
    }
}