using KTMPOS.BAL.Services.Inventory.Categories;
using KTMPOS.BAL.Services.Inventory.Products;
using KTMPOS.BAL.Services.Inventory.SubCategories;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace KTMPOS.Web.Controllers.Inventory
{
    public partial class InventoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IProductService _productService;

        public InventoryController(ICategoryService categoryService, ISubCategoryService subCategoryService,
                                   IProductService productService)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _productService = productService;
        }

        private async Task LoadViewBagsAsync()
        {
            await LoadCategoriesViewBagAsync();
            await LoadSubCategoriesViewBagAsync();
        }

        private async Task LoadCategoriesViewBagAsync()
        {
            var result = await _categoryService.GetAllAsync();
            var categories = result
                             .Data
                             .Select(c => new SelectListItem
                             {
                                 Value = c.Id.ToString(),
                                 Text = c.Name
                             })
                             .ToList();
            categories.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = "Please select a category"
            });
            ViewBag.Categories = categories;
        }

        private async Task LoadSubCategoriesViewBagAsync()
        {
            var result = await _subCategoryService.GetAllAsync();
            var subCategories = result
                                .Data
                                .Select(c => new SelectListItem
                                {
                                    Value = c.Id.ToString(),
                                    Text = c.Name
                                })
                                .ToList();
            subCategories.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = "Please select a sub category"
            });
            ViewBag.SubCategories = subCategories;
        }
    }
}