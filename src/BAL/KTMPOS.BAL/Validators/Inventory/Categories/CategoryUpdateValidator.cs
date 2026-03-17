using FluentValidation;

using KTMPOS.Common.Model.Inventory.Categories;

namespace KTMPOS.BAL.Validators.Inventory.Categories
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdate>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

            Include(new CategoryCreateValidator());
        }
    }
}