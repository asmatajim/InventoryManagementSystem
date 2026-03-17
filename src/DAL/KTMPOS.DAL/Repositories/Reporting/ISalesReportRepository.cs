using KTMPOS.Common.Model.Reporting;

namespace KTMPOS.DAL.Repositories.Reporting
{
    public interface ISalesReportRepository
    {
        Task<SalesReport> GetSalesReportAsync(DateTime startDate, DateTime endDate);
    }
}