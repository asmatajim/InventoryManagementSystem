using FluentValidation;

using KTMPOS.Common.Model.PurchaseBilling;

namespace KTMPOS.BAL.Validators.PurchaseBilling
{
    public class PurchaseCreateValidator : AbstractValidator<PurchaseCreate>
    {
        public PurchaseCreateValidator()
        {
            RuleFor(x => x.SupplierId)
            .NotEmpty()
            .WithMessage("Supplier id is required.");

            RuleFor(x => x.CreatedBy)
            .NotEmpty()
            .WithMessage("Created by is required.");

            RuleFor(x => x.PurchaseDetails)
            .NotEmpty()
            .WithMessage("Purchase details is required.");

            RuleForEach(x => x.PurchaseDetails)
            .SetValidator(new PurchaseDetailCreateValidator());
        }
    }
}