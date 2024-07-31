namespace SuperDuperMart.Shared.Extensions
{
    public static class DateTimeFormatting
    {
        /// <summary>
        /// Use for custom datetime formatting that will looks something like this, 31-10-2024 15:32:14
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToDateTimeFormat(this DateTime date)
        {
            return date.ToString("dd-MM-yyyy HH:mm:ss");
        }
    }
}
