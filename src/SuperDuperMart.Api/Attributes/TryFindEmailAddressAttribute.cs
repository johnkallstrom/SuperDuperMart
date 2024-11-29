using System.ComponentModel.DataAnnotations;

namespace SuperDuperMart.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class TryFindEmailAddressAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return base.IsValid(value);
        }
    }
}
