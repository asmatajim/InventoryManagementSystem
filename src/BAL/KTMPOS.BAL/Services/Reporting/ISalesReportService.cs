using KTMPOS.Common.Enumerations;
using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.Reporting;

namespace KTMPOS.BAL.Services.Reporting
{
    public interface ISalesReportService
    {
        Output<string> GetSalesReportType();

        Task<Output<SalesReport>> GetSalesReportAsync(ReportType reportType);
    }
}