using FluentValidation;

using KTMPOS.BAL.Validators.Inventory.Categories;
using KTMPOS.Common.Model.Inventory.SubCategories;

namespace KTMPOS.BAL.Validators.Inventory.SubCategories
{
    public class SubCategoryCreateValidator : AbstractValidator<SubCategoryCreate>
    {
        public SubCategoryCreateValidator()
        {
            RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("Category is required.");

            Include(new CategoryCreateValidator());
        }
    }
}