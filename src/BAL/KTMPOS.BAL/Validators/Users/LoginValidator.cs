using FluentValidation;

using KTMPOS.Common.Model.Users;

namespace KTMPOS.BAL.Validators.Users
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage("User name is required")
            .MaximumLength(50)
            .WithMessage("User name must not exceed 50 characters");

            RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MaximumLength(20)
            .WithMessage("Password must not exceed 20 characters");
        }
    }
}