using FluentValidation;

using KTMPOS.Common.Model.Users;

namespace KTMPOS.BAL.Validators.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage("User name is required")
            .MaximumLength(50)
            .WithMessage("User name must not exceed 50 characters");

            RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Invalid email");

            RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MaximumLength(20)
            .WithMessage("Password must not exceed 20 characters");

            RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .WithMessage("Confirm password is required")
            .Equal(x => x.Password)
            .WithMessage("Password and confirm password do not match");
        }
    }
}