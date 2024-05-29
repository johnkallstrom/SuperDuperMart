using Bogus;
using SuperDuperMart.Core.Entities;

namespace SuperDuperMart.Persistence.Fakers
{
    public class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker()
        {
        }
    }
}
