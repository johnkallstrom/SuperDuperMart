namespace SuperDuperMart.Web.Extensions
{
    public static class DateTimeFormatting
    {
        public static string ToCustomDateTimeFormat(this DateTime date)
        {
            return date.ToString("HH:mm:ss dd-MM-yyyy");
        }

        public static string ToCustomDateFormat(this DateTime date)
        {
            return date.ToString("dd-MM-yyyy");
        }
    }
}
