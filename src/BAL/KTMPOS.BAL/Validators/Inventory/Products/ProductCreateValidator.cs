using FluentValidation;

using KTMPOS.BAL.Validators.Inventory.Categories;
using KTMPOS.Common.Model.Inventory.Products;

namespace KTMPOS.BAL.Validators.Inventory.Products
{
    public class ProductCreateValidator : AbstractValidator<ProductCreate>
    {
        public ProductCreateValidator()
        {
            RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("Category is required.");

            RuleFor(x => x.SubCategoryId)
            .NotEmpty()
            .WithMessage("Sub category is required.");

            RuleFor(x => x.PurchasePrice)
            .NotEmpty()
            .WithMessage("Purchase price is required.");

            RuleFor(x => x.SellingPrice)
            .NotEmpty()
            .WithMessage("Selling price is required.")
            .GreaterThanOrEqualTo(x => x.PurchasePrice * 1.05m)
            .WithMessage("Selling price must have at least 5% margin.")
            .LessThanOrEqualTo(x => x.PurchasePrice * 1.45m)
            .WithMessage("Selling price can have max 45% margin.");

            Include(x => new CategoryCreateValidator());
        }
    }
}