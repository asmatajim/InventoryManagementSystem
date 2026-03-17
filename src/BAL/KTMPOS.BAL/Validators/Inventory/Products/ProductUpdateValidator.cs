using FluentValidation;

using KTMPOS.Common.Model.Inventory.Products;

namespace KTMPOS.BAL.Validators.Inventory.Products
{
    public class ProductUpdateValidator : AbstractValidator<ProductUpdate>
    {
        public ProductUpdateValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

            Include(x => new ProductCreateValidator());
        }
    }
}