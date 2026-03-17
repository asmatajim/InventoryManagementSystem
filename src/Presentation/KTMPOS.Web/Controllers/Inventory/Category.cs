using KTMPOS.Common.Constants;
using KTMPOS.Common.Enumerations;
using KTMPOS.Common.Model.Inventory.Categories;
using KTMPOS.Web.Utilities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KTMPOS.Web.Controllers.Inventory
{
    public partial class InventoryController
    {
        [HttpGet("Category/Get")]
        [Authorize(Policy = Policy.InventoryListOrCreate)]
        public async Task<IActionResult> CategoryList()
        {
            var result = await _categoryService.GetAllAsync();
            if(result.Status == Status.Failed)
            {
                TempData[Message.ErrorMessage] = result.Error;
            }

            return View(result.Data);
        }

        [HttpGet("Category/Create")]
        [Authorize(Policy = Policy.InventoryListOrCreate)]
        public async Task<IActionResult> CategoryCreate()
        {
            return View();
        }

        [HttpPost("Category/Create")]
        [Authorize(Policy = Policy.InventoryListOrCreate)]
        public async Task<IActionResult> CategoryCreate(CategoryCreate request)
        {
            request.CreatedBy = GetCurrentUserId();
            var result = await _categoryService.SaveAsync(request);
            if(result.Status == Status.Failed)
            {
                TempData[Message.ErrorMessage] = ProcessMessage.FailedAlert(result, ModelState);
                return View(request);
            }

            TempData[Message.SuccessMessage] = result.Message;
            return RedirectToAction(nameof(CategoryList));
        }

        [HttpGet("Category/Update")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> CategoryUpdate(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            if(result.Status == Status.Failed)
            {
                TempData[Message.ErrorMessage] = result.Error;
                return RedirectToAction(nameof(CategoryList));
            }

            var detail = result.Data.SingleOrDefault();
            CategoryUpdate model = new()
            {
                Id = detail.Id,
                Name = detail.Name
            };
            return View(model);
        }

        [HttpPost("Category/Update")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> CategoryUpdate(CategoryUpdate request)
        {
            request.CreatedBy = GetCurrentUserId();
            var result = await _categoryService.UpdateAsync(request);
            if(result.Status == Status.Failed)
            {
                TempData[Message.ErrorMessage] = ProcessMessage.FailedAlert(result, ModelState);
                return View(request);
            }

            TempData[Message.SuccessMessage] = result.Message;
            return RedirectToAction(nameof(CategoryList));
        }

        [HttpDelete("Category/Delete/{id}")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> CategoryDelete(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            return Json(result);
        }
    }
}