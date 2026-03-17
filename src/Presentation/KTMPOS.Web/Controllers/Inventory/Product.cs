using KTMPOS.Common.Constants;
using KTMPOS.Common.Enumerations;
using KTMPOS.Common.Model.Inventory.Products;
using KTMPOS.Web.Utilities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KTMPOS.Web.Controllers.Inventory
{
    public partial class InventoryController
    {
        [HttpGet("Product/SubCategory/{categoryId}")]
        [Authorize(Policy = Policy.InventoryListOrCreate)]
        public async Task<IActionResult> SubCategoryByCategoryId(int categoryId)
        {
            var result = await _subCategoryService.FetchByCategoryIdAsync(categoryId);
            if(result.Status == Status.Failed)
            {
                TempData[Message.ErrorMessage] = result.Error;
            }

            return Json(result);
        }

        [HttpGet("Product/Get")]
        [Authorize(Policy = Policy.InventoryListOrCreate)]
        public async Task<IActionResult> ProductList()
        {
            var result = await _productService.GetAllAsync();
            if(result.Status == Status.Failed)
            {
                TempData[Message.ErrorMessage] = result.Error;
            }

            return View(result.Data);
        }

        [HttpGet("Product/Create")]
        [Authorize(Policy = Policy.InventoryListOrCreate)]
        public async Task<IActionResult> ProductCreate()
        {
            await LoadViewBagsAsync();
            return View();
        }

        [HttpPost("Product/Create")]
        [Authorize(Policy = Policy.InventoryListOrCreate)]
        public async Task<IActionResult> ProductCreate(ProductCreate request)
        {
            request.CreatedBy = GetCurrentUserId();
            var result = await _productService.SaveAsync(request);
            if(result.Status == Status.Failed)
            {
                await LoadViewBagsAsync();
                TempData[Message.ErrorMessage] = ProcessMessage.FailedAlert(result, ModelState);
                return View(request);
            }

            TempData[Message.SuccessMessage] = result.Message;
            return RedirectToAction(nameof(ProductList));
        }

        [HttpGet("Product/Update")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> ProductUpdate(int id)
        {
            await LoadViewBagsAsync();
            var result = await _productService.GetByIdAsync(id);
            if(result.Status == Status.Failed)
            {
                TempData[Message.ErrorMessage] = result.Error;
                return RedirectToAction(nameof(ProductList));
            }

            var detail = result.Data.SingleOrDefault();
            ProductUpdate model = new()
            {
                Id = detail.Id,
                CategoryId = detail.CategoryId,
                SubCategoryId = detail.SubCategoryId,
                PurchasePrice = Convert.ToDecimal(detail.PurchasePrice),
                SellingPrice = Convert.ToDecimal(detail.SellingPrice),
                Name = detail.Name
            };
            return View(model);
        }

        [HttpPost("Product/Update")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> ProductUpdate(ProductUpdate request)
        {
            request.CreatedBy = GetCurrentUserId();
            var result = await _productService.UpdateAsync(request);
            if(result.Status == Status.Failed)
            {
                await LoadViewBagsAsync();
                TempData[Message.ErrorMessage] = ProcessMessage.FailedAlert(result, ModelState);
                return View(request);
            }

            TempData[Message.SuccessMessage] = result.Message;
            return RedirectToAction(nameof(ProductList));
        }

        [HttpDelete("Product/Delete/{id}")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var result = await _productService.DeleteAsync(id);
            return Json(result);
        }
    }
}