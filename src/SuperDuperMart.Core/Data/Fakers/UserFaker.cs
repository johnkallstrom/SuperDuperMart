using Bogus;

namespace SuperDuperMart.Core.Data.Fakers
{
    public class UserFaker : Faker<User>
    {
        public UserFaker()
        {
            RuleFor(u => u.Avatar, f => f.Image.PlaceholderUrl(width: 640, height: 480));
            RuleFor(u => u.FirstName, f => f.Person.FirstName);
            RuleFor(u => u.LastName, f => f.Person.LastName);
            RuleFor(u => u.UserName, f => f.Person.UserName);
            RuleFor(u => u.Email, f => f.Person.Email);
            RuleFor(u => u.Birthday, f =>
            {
                var today = DateTime.Now;
                var dateOfBirth = DateOnly.FromDateTime(f.Person.DateOfBirth);
                int age = today.Year - dateOfBirth.Year;

                return age >= 21 ? dateOfBirth : new DateOnly(2000, 1, 1);
            });
            RuleFor(u => u.Created, f => DateTime.Now);
            RuleFor(u => u.Location, f => new Location
            {
                ZipCode = f.Person.Address.ZipCode,
                StreetName = f.Person.Address.Street,
                City = f.Person.Address.City,
                Created = DateTime.Now,
            });
            RuleFor(u => u.Cart, f => new Cart
            {
                Purchased = false,
                TotalCost = 0,
                Created = DateTime.Now,
            });
        }
    }
}
