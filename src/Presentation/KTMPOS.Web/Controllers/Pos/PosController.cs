using KTMPOS.BAL.Services.Inventory.Products;
using KTMPOS.BAL.Services.POS;
using KTMPOS.Common.Model.POS;

using Microsoft.AspNetCore.Mvc;

namespace KTMPOS.Web.Controllers.Pos
{
    public class PosController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ISalesService _salesService;

        public PosController(IProductService productService, ISalesService salesService)
        {
            _productService = productService;
            _salesService = salesService;
        }

        public IActionResult Sales()
        {
            return View();
        }

        [HttpGet("Product/Get")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllAsync();
            return Json(result);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(SalesCreate request)
        {
            request.CreatedBy = GetCurrentUserId();
            var result = await _salesService.SaveAsync(request);
            return Json(result);
        }
    }
}