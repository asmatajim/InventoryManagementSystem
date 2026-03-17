using FluentValidation;

using KTMPOS.Common.Model.PurchaseBilling;

namespace KTMPOS.BAL.Validators.PurchaseBilling
{
    public class PurchaseDetailCreateValidator : AbstractValidator<PurchaseDetailCreate>
    {
        public PurchaseDetailCreateValidator()
        {
            RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("Product id is required.");

            RuleFor(x => x.Qty)
            .NotEmpty()
            .WithMessage("Quantity is required.");
        }
    }
}