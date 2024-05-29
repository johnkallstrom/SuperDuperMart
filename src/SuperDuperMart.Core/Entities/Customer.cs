using System.ComponentModel.DataAnnotations;

namespace SuperDuperMart.Core.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string Username { get; set; } = default!;
        public required string Email { get; set; }

        public Address Address { get; set; } = default!;
    }
}
