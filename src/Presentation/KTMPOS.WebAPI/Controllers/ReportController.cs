using KTMPOS.BAL.Services.Reporting;
using KTMPOS.Common.Enumerations;

using Microsoft.AspNetCore.Mvc;

namespace KTMPOS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ISalesReportService _salesReportService;

        public ReportController(ISalesReportService salesReportService)
        {
            _salesReportService = salesReportService;
        }

        [HttpGet("Get/ReportType")]
        public IActionResult GetReportType()
        {
            var result = _salesReportService.GetSalesReportType();
            return Ok(result);
        }

        [HttpGet("Get/Report/Sales/{type}")]
        public async Task<IActionResult> GetSalesReport(string type)
        {
            ReportType reportType = (ReportType)Enum.Parse(typeof(ReportType), type);
            var result = await _salesReportService.GetSalesReportAsync(reportType);
            return Ok(result);
        }
    }
}