﻿using Bogus;
using SuperDuperMart.Core.Entities;

namespace SuperDuperMart.Persistence.Fakers
{
    public class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker()
        {
            RuleFor(c => c.FirstName, f => f.Person.FirstName);
            RuleFor(c => c.LastName, f => f.Person.LastName);
            RuleFor(c => c.Username, f => f.Person.UserName);
            RuleFor(c => c.Email, f => f.Person.Email);
            RuleFor(c => c.Address, f => new Address
            {
                ZipCode = f.Person.Address.ZipCode,
                StreetName = f.Person.Address.Street,
                City = f.Person.Address.City,
            });
        }
    }
}
