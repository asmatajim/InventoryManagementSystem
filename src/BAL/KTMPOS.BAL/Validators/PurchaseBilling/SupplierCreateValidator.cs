using FluentValidation;

using KTMPOS.Common.Model.PurchaseBilling;

namespace KTMPOS.BAL.Validators.PurchaseBilling
{
    public class SupplierCreateValidator : AbstractValidator<SupplierCreate>
    {
        public SupplierCreateValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(200)
            .WithMessage("Name cannot exceed 200 characters.");

            RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number is required.")
            .Matches(@"^[9]\d{9}$")
            .WithMessage("Invalid mobile number(Eg: 9841234567).");

            RuleFor(x => x.EmailAddress)
            .NotEmpty()
            .WithMessage("Email address is required.")
            .EmailAddress()
            .WithMessage("Invalid email address format.");

            RuleFor(x => x.Address)
            .MaximumLength(500)
            .WithMessage("Address cannot exceed 500 characters.");

            RuleFor(x => x.CreatedBy)
            .NotEmpty()
            .WithMessage("Created by is required.");
        }
    }
}