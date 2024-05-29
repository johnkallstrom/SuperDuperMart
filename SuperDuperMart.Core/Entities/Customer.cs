using System.ComponentModel.DataAnnotations;

namespace SuperDuperMart.Core.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;

        public Address Address { get; set; } = default!;
    }
}
