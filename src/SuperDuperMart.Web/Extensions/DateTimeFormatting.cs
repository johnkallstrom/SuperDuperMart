namespace SuperDuperMart.Web.Extensions
{
    public static class DateTimeFormatting
    {
        public static string ToSimplifiedDateFormat(this DateTime date)
        {
            return date.ToString("MMMM dd");
        }
    }
}
