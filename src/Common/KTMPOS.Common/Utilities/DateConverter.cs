using KTMPOS.Common.Constants;

namespace KTMPOS.Common.Utilities
{
    public static class DateConverter
    {
        public static string FormatDate(this DateTime? date, string format = ApplicationConstant.DateFormat)
        {
            if(!date.HasValue)
            {
                return null;
            }

            string convertedDate = date.Value.ToString(format);
            return convertedDate;
        }

        public static string FormatDate(this DateOnly date, string format = ApplicationConstant.DateFormat)
        {
            string convertedDate = date.ToString(format);
            return convertedDate;
        }
    }
}