using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.POS;

namespace KTMPOS.BAL.Services.POS
{
    public interface ISalesService
    {
        Task<Output> SaveAsync(SalesCreate request);
    }
}