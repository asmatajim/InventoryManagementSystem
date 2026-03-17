using FluentValidation;

using KTMPOS.Common.Model.PurchaseBilling;

namespace KTMPOS.BAL.Validators.PurchaseBilling
{
    public class SupplierUpdateValidator : AbstractValidator<SupplierUpdate>
    {
        public SupplierUpdateValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

            Include(x => new SupplierCreateValidator());
        }
    }
}