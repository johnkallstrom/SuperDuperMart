﻿using System.ComponentModel.DataAnnotations;

namespace SuperDuperMart.Shared.Models.Carts
{
    public class CartCreateDto
    {
        public bool Purchased { get; set; }

        [Required(ErrorMessage = "Please enter a user id")]
        public int UserId { get; set; }
    }
}
