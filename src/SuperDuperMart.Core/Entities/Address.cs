using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperDuperMart.Core.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string? ZipCode { get; set; }
        public required string StreetName { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;
    }
}
