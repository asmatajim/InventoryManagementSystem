using FluentValidation;

using KTMPOS.Common.Model.POS;

namespace KTMPOS.BAL.Validators.POS
{
    public class SalesCreateValidator : AbstractValidator<SalesCreate>
    {
        public SalesCreateValidator()
        {
            RuleFor(x => x.CreatedBy)
            .NotEmpty()
            .WithMessage("Created by is required.");

            RuleFor(x => x.SalesDetails)
            .NotEmpty()
            .WithMessage("Sales details is required.");

            RuleForEach(x => x.SalesDetails)
            .SetValidator(new SalesDetailCreateValidator());
        }
    }
}