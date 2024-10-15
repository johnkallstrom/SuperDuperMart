using Bogus;

namespace SuperDuperMart.Core.Data.Fakers
{
    public class UserFaker : Faker<User>
    {
        private IEnumerable<string> _roles = ["Administrator", "Customer"];

        public UserFaker()
        {
            RuleFor(u => u.Avatar, f => f.Image.LoremFlickrUrl());
            RuleFor(u => u.FirstName, f => f.Person.FirstName);
            RuleFor(u => u.LastName, f => f.Person.LastName);
            RuleFor(u => u.UserName, f => f.Person.UserName);
            RuleFor(u => u.Email, f => f.Person.Email);
            RuleFor(u => u.Roles, f =>
            {
                string role = f.PickRandom(_roles);
                return [role];
            });
            RuleFor(u => u.Location, f => new Location
            {
                ZipCode = f.Person.Address.ZipCode,
                StreetName = f.Person.Address.Street,
                City = f.Person.Address.City,
                Created = DateTime.Now,
            });
            RuleFor(u => u.Cart, f => new Cart
            {
                SessionId = Guid.NewGuid(),
                Purchased = false,
                TotalCost = 0,
                Created = DateTime.Now,
            });
        }
    }
}
