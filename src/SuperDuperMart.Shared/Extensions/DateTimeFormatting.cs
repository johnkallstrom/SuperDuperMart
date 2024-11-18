namespace SuperDuperMart.Shared.Extensions
{
    public static class DateTimeFormatting
    {
        public static string ToSpecifiedDateFormat(this DateTime date)
        {
            return date.ToString("dd-MM-yyyy HH:mm:ss");
        }

        public static string ToDateFormat(this DateTime date)
        {
            return date.ToString("dd-MM-yyyy");
        }
    }
}
