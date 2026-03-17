using KTMPOS.Common.Model.Common;
using KTMPOS.Web.Extensions;

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KTMPOS.Web.Utilities
{
    public static class ProcessMessage
    {
        public static string FailedAlert(Output result, ModelStateDictionary modelState)
        {
            if(result.ValidationResult is not null)
            {
                var validationErrors = result
                                       .ValidationResult
                                       .Errors
                                       .Select(x => x.ErrorMessage);
                string errors = String.Join(Environment.NewLine, validationErrors);
                result.ValidationResult.AddToModelState(modelState);
                return null;
            }

            return result.Error;
        }
    }
}