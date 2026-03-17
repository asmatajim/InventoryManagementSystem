using KTMPOS.Common.Constants;
using KTMPOS.Common.Enumerations;
using KTMPOS.Common.Model.PurchaseBilling;
using KTMPOS.Web.Utilities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KTMPOS.Web.Controllers.PurchaseBilling
{
    public partial class PurchaseController
    {
        [HttpGet("Supplier/Get")]
        [Authorize(Policy = Policy.InventoryListOrCreate)]
        public async Task<IActionResult> SupplierList()
        {
            var result = await _supplierService.GetAllAsync();
            if(result.Status == Status.Failed)
            {
                TempData[Message.ErrorMessage] = result.Error;
            }

            return View(result.Data);
        }

        [HttpGet("Supplier/Create")]
        [Authorize(Policy = Policy.InventoryListOrCreate)]
        public async Task<IActionResult> SupplierCreate()
        {
            return View();
        }

        [HttpPost("Supplier/Create")]
        [Authorize(Policy = Policy.InventoryListOrCreate)]
        public async Task<IActionResult> SupplierCreate(SupplierCreate request)
        {
            request.CreatedBy = GetCurrentUserId();
            var result = await _supplierService.SaveAsync(request);
            if(result.Status == Status.Failed)
            {
                TempData[Message.ErrorMessage] = ProcessMessage.FailedAlert(result, ModelState);
                return View(request);
            }

            TempData[Message.SuccessMessage] = result.Message;
            return RedirectToAction(nameof(SupplierList));
        }

        [HttpGet("Supplier/Update")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> SupplierUpdate(int id)
        {
            var result = await _supplierService.GetByIdAsync(id);
            if(result.Status == Status.Failed)
            {
                TempData[Message.ErrorMessage] = result.Error;
                return RedirectToAction(nameof(SupplierList));
            }

            var detail = result.Data.SingleOrDefault();
            SupplierUpdate model = new()
            {
                Id = detail.Id,
                Name = detail.Name,
                ContactPerson = detail.ContactPerson,
                EmailAddress = detail.EmailAddress,
                PhoneNumber = detail.PhoneNumber,
                Address = detail.Address
            };
            return View(model);
        }

        [HttpPost("Supplier/Update")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> SupplierUpdate(SupplierUpdate request)
        {
            request.CreatedBy = GetCurrentUserId();
            var result = await _supplierService.UpdateAsync(request);
            if(result.Status == Status.Failed)
            {
                TempData[Message.ErrorMessage] = ProcessMessage.FailedAlert(result, ModelState);
                return View(request);
            }

            TempData[Message.SuccessMessage] = result.Message;
            return RedirectToAction(nameof(SupplierList));
        }

        [HttpDelete("Supplier/Delete/{id}")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> SupplierDelete(int id)
        {
            var result = await _supplierService.DeleteAsync(id);
            return Json(result);
        }
    }
}