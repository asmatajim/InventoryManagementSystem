using KTMPOS.DAL.Entities.POS;

namespace KTMPOS.DAL.Repositories.POS
{
    public interface ISalesRepository
    {
        Task SaveAsync(Sales entity);
    }
}