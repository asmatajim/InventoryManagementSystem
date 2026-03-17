using FluentValidation.Results;

using KTMPOS.Common.Constants;
using KTMPOS.Common.Enumerations;
using KTMPOS.Common.Model.Common;

namespace KTMPOS.Common.Utilities
{
    public static class OutputConverter
    {
        #region Success

        public static Output SetSuccess(string message)
        {
            return new()
            {
                Status = Status.Success,
                Message = message
            };
        }

        public static Output<T> SetSuccess<T>(List<T> data) where T : class
        {
            return new()
            {
                Status = Status.Success,
                Message = Message.Success,
                Data = data
            };
        }

        public static Output<T> SetSuccess<T>(string message, List<T> data) where T : class
        {
            return new()
            {
                Status = Status.Success,
                Message = message,
                Data = data
            };
        }

        #endregion Success

        #region Failure

        public static Output SetFailed(string error)
        {
            return new()
            {
                Status = Status.Failed,
                Message = Message.Failed,
                Error = error
            };
        }

        public static Output SetFailed(ValidationResult validationResult)
        {
            return new()
            {
                Status = Status.Failed,
                Message = Message.ValidationFailed,
                ValidationResult = validationResult
            };
        }

        public static Output<T> SetFailed<T>(string error) where T : class
        {
            return new()
            {
                Status = Status.Failed,
                Message = Message.Failed,
                Error = error
            };
        }

        public static Output<T> SetFailed<T>(ValidationResult validationResult) where T : class
        {
            return new()
            {
                Status = Status.Failed,
                Message = Message.ValidationFailed,
                ValidationResult = validationResult
            };
        }

        #endregion Failure
    }
}