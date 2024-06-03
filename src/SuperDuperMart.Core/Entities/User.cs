﻿namespace SuperDuperMart.Core.Entities
{
    public class User : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        public Location Location { get; set; } = default!;
    }
}
