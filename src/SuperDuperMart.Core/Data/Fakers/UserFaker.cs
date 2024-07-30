﻿using Bogus;

namespace SuperDuperMart.Core.Data.Fakers
{
    public class UserFaker : Faker<User>
    {
        public UserFaker()
        {
            RuleFor(c => c.FirstName, f => f.Person.FirstName);
            RuleFor(c => c.LastName, f => f.Person.LastName);
            RuleFor(c => c.UserName, f => f.Person.UserName);
            RuleFor(c => c.Email, f => f.Person.Email);
            RuleFor(c => c.Location, f => new Location
            {
                ZipCode = f.Person.Address.ZipCode,
                StreetName = f.Person.Address.Street,
                City = f.Person.Address.City,
                Created = DateTime.Now
            });
        }
    }
}
