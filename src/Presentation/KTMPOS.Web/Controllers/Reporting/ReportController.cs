using Microsoft.AspNetCore.Mvc;

namespace KTMPOS.Web.Controllers.Reporting
{
    public class ReportController : BaseController
    {
        [HttpGet("sales")]
        public IActionResult Sales()
        {
            return View();
        }
    }
}