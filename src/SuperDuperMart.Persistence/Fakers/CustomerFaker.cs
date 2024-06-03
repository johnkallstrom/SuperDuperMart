using Bogus;

namespace SuperDuperMart.Persistence.Fakers
{
    public class CustomerFaker : Faker<User>
    {
        public CustomerFaker()
        {
            RuleFor(c => c.FirstName, f => f.Person.FirstName);
            RuleFor(c => c.LastName, f => f.Person.LastName);
            RuleFor(c => c.Username, f => f.Person.UserName);
            RuleFor(c => c.Email, f => f.Person.Email);
            RuleFor(c => c.PasswordHash, f => f.Internet.Password(length: 15));
            RuleFor(c => c.Address, f => new Address
            {
                ZipCode = f.Person.Address.ZipCode,
                StreetName = f.Person.Address.Street,
                City = f.Person.Address.City,
                Created = DateTime.Now
            });
            RuleFor(c => c.Created, DateTime.Now);
        }
    }
}
