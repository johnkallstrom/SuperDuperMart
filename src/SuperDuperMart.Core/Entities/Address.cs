using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperDuperMart.Core.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string ZipCode { get; set; } = default!;
        public string StreetName { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;
    }
}
