namespace SuperDuperMart.Shared.Extensions
{
    public static class DateTimeFormatting
    {
        public static string ToSpecifiedDateFormat(this DateTime date)
        {
            return date.ToString("dd-MM-yyyy HH:mm:ss");
        }
    }
}
