using FluentValidation.Results;

using KTMPOS.Common.Enumerations;

namespace KTMPOS.Common.Model.Common
{
    public class Output
    {
        public Status Status { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }

    public class Output<T> : Output
    {
        public List<T> Data { get; set; }

        public Output()
        {
            Data = [];
        }
    }
}