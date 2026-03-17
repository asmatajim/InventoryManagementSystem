using Microsoft.EntityFrameworkCore.Storage;

namespace KTMPOS.DAL.Utilities
{
    public interface ITransactionManager
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}