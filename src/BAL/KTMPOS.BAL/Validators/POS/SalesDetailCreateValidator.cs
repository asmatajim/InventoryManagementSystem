using FluentValidation;

using KTMPOS.BAL.Validators.PurchaseBilling;
using KTMPOS.Common.Model.POS;

namespace KTMPOS.BAL.Validators.POS
{
    public class SalesDetailCreateValidator : AbstractValidator<SalesDetailCreate>
    {
        public SalesDetailCreateValidator()
        {
            Include(new PurchaseDetailCreateValidator());
        }
    }
}