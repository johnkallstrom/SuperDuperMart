﻿using System.ComponentModel.DataAnnotations;

namespace SuperDuperMart.Core.Dtos.Users
{
    public record UserCreateDto
    {
        [Required(ErrorMessage = "Please enter a firstname")]
        public string FirstName { get; init; } = default!;

        [Required(ErrorMessage = "Please enter a lastname")]
        public string LastName { get; init; } = default!;

        public string? Username { get; init; }

        [Required(ErrorMessage = "Please enter a email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; init; } = default!;

        [Required(ErrorMessage = "Please enter a valid password")]
        [DataType(DataType.Password)]
        public string Password { get; init; } = default!;

        public LocationCreateDto Location { get; set; } = default!;
    }
}
