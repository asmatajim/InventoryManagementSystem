using FluentValidation;

using KTMPOS.Common.Model.Inventory.SubCategories;

namespace KTMPOS.BAL.Validators.Inventory.SubCategories
{
    public class SubCategoryUpdateValidator : AbstractValidator<SubCategoryUpdate>
    {
        public SubCategoryUpdateValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

            Include(new SubCategoryCreateValidator());
        }
    }
}