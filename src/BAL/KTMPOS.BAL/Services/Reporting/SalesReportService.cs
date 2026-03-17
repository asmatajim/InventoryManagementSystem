using KTMPOS.Common.Enumerations;
using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.Reporting;
using KTMPOS.Common.Utilities;
using KTMPOS.DAL.Repositories.Reporting;

namespace KTMPOS.BAL.Services.Reporting
{
    public class SalesReportService : ISalesReportService
    {
        private readonly ISalesReportRepository _salesReportRepository;

        public SalesReportService(ISalesReportRepository salesReportRepository)
        {
            _salesReportRepository = salesReportRepository;
        }

        public Output<string> GetSalesReportType()
        {
            try
            {
                List<string> result = Enum.GetNames(typeof(ReportType)).ToList();
                return OutputConverter.SetSuccess(result);
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed<string>(ex.Message);
            }
        }

        public async Task<Output<SalesReport>> GetSalesReportAsync(ReportType reportType)
        {
            try
            {
                CalculateDateRange(reportType, out DateTime startDate, out DateTime endDate);
                SalesReport result = await _salesReportRepository.GetSalesReportAsync(startDate, endDate);
                return OutputConverter.SetSuccess([result]);
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed<SalesReport>(ex.Message);
            }
        }

        private void CalculateDateRange(ReportType reportType, out DateTime startDate, out DateTime endDate)
        {
            DateTime today = DateTime.Today;
            switch(reportType)
            {
                case ReportType.Daily:
                    startDate = today;
                    endDate = today.AddDays(1);
                    break;

                case ReportType.Weekly:
                    int daysToSubtract = (int)today.DayOfWeek;
                    startDate = today.AddDays(-daysToSubtract);
                    endDate = startDate.AddDays(7);
                    break;

                case ReportType.Monthly:
                    startDate = new DateTime(today.Year, today.Month, 1);
                    endDate = startDate.AddMonths(1);
                    break;

                case ReportType.Yearly:
                    startDate = new DateTime(today.Year, 1, 1);
                    endDate = startDate.AddYears(1);
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"Invalid report type {reportType.ToString()}");
            }
        }
    }
}