using KTMPOS.Common.Model.Reporting;
using KTMPOS.DAL.Repositories.Dapper;

namespace KTMPOS.DAL.Repositories.Reporting
{
    public class SalesReportRepository : ISalesReportRepository
    {
        private readonly IDapperRepository _dapper;

        public SalesReportRepository(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        public async Task<SalesReport> GetSalesReportAsync(DateTime startDate, DateTime endDate)
        {
            Dictionary<string, object> parameters = new()
            {
                { "@startDate", startDate },
                { "@endDate", endDate }
            };
            var salesReport = await _dapper.QuerySingleOrDefaultAsync<SalesReport>("usp_get_sales_report", parameters);
            return salesReport;
        }
    }
}