﻿using System.ComponentModel.DataAnnotations;

namespace SuperDuperMart.Shared.Models.Authentication
{
    public record LoginModel
    {
        [Required(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Please enter a valid password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;
        public bool IsAdministrator { get; set; }
    }
}