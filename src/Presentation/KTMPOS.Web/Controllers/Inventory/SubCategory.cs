using KTMPOS.Common.Constants;
using KTMPOS.Common.Enumerations;
using KTMPOS.Common.Model.Inventory.SubCategories;
using KTMPOS.Web.Utilities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KTMPOS.Web.Controllers.Inventory
{
    public partial class InventoryController
    {
        [HttpGet("SubCategory/Get")]
        [Authorize(Policy = Policy.InventoryListOrCreate)]
        public async Task<IActionResult> SubCategoryList()
        {
            var result = await _subCategoryService.GetAllAsync();
            if(result.Status == Status.Failed)
            {
                TempData[Message.ErrorMessage] = result.Error;
            }

            return View(result.Data);
        }

        [HttpGet("SubCategory/Create")]
        [Authorize(Policy = Policy.InventoryListOrCreate)]
        public async Task<IActionResult> SubCategoryCreate()
        {
            await LoadCategoriesViewBagAsync();
            return View();
        }

        [HttpPost("SubCategory/Create")]
        [Authorize(Policy = Policy.InventoryListOrCreate)]
        public async Task<IActionResult> SubCategoryCreate(SubCategoryCreate request)
        {
            request.CreatedBy = GetCurrentUserId();
            var result = await _subCategoryService.SaveAsync(request);
            if(result.Status == Status.Failed)
            {
                await LoadCategoriesViewBagAsync();
                TempData[Message.ErrorMessage] = ProcessMessage.FailedAlert(result, ModelState);
                return View(request);
            }

            TempData[Message.SuccessMessage] = result.Message;
            return RedirectToAction(nameof(SubCategoryList));
        }

        [HttpGet("SubCategory/Update")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> SubCategoryUpdate(int id)
        {
            await LoadCategoriesViewBagAsync();
            var result = await _subCategoryService.GetByIdAsync(id);
            if(result.Status == Status.Failed)
            {
                TempData[Message.ErrorMessage] = result.Error;
                return RedirectToAction(nameof(SubCategoryList));
            }

            var detail = result.Data.SingleOrDefault();
            SubCategoryUpdate model = new()
            {
                Id = detail.Id,
                CategoryId = detail.CategoryId,
                Name = detail.Name
            };
            return View(model);
        }

        [HttpPost("SubCategory/Update")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> SubCategoryUpdate(SubCategoryUpdate request)
        {
            request.CreatedBy = GetCurrentUserId();
            var result = await _subCategoryService.UpdateAsync(request);
            if(result.Status == Status.Failed)
            {
                await LoadCategoriesViewBagAsync();
                TempData[Message.ErrorMessage] = ProcessMessage.FailedAlert(result, ModelState);
                return View(request);
            }

            TempData[Message.SuccessMessage] = result.Message;
            return RedirectToAction(nameof(SubCategoryList));
        }

        [HttpDelete("SubCategory/Delete/{id}")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> SubCategoryDelete(int id)
        {
            var result = await _subCategoryService.DeleteAsync(id);
            return Json(result);
        }
    }
}