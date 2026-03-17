using KTMPOS.Common.Model.PurchaseBilling;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace KTMPOS.Web.Controllers.PurchaseBilling
{
    public partial class PurchaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Product/Get")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllAsync();
            return Json(result);
        }

        [HttpGet("SupplierList/Get")]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var result = await _supplierService.FetchAllAsync();
            return Json(result);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(PurchaseCreate request)
        {
            request.CreatedBy = GetCurrentUserId();
            var result = await _purchaseService.SaveAsync(request);
            return Json(result);
        }
    }
}