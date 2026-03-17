using FluentValidation;

using KTMPOS.Common.Model.Inventory.Categories;

namespace KTMPOS.BAL.Validators.Inventory.Categories
{
    public class CategoryCreateValidator : AbstractValidator<CategoryCreate>
    {
        public CategoryCreateValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.CreatedBy)
            .NotEmpty()
            .WithMessage("Created by is required.");
        }
    }
}