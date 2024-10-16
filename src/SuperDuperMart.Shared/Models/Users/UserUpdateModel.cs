﻿namespace SuperDuperMart.Shared.Models.Users
{
    public record UserUpdateModel
    {
        public string? Avatar { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public LocationUpdateModel Location { get; set; } = new();
    }
}
