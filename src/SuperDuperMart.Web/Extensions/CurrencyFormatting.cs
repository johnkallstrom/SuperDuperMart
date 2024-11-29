using System.Globalization;

namespace SuperDuperMart.Web.Extensions
{
    public static class CurrencyFormatting
    {
        public static string ToCurrency(this decimal value, string culture)
        {
            return value.ToString("C", CultureInfo.CreateSpecificCulture("sv-SE"));
        }
    }
}
