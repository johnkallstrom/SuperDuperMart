using System.ComponentModel.DataAnnotations;

namespace SuperDuperMart.Shared.Models.Carts
{
    public class CartCreateModel
    {
        [Required(ErrorMessage = "Please enter a session id")]
        public Guid SessionId { get; set; }

        public bool Purchased { get; set; }

        [Required(ErrorMessage = "Please enter a user id")]
        public int UserId { get; set; }

        public List<CartItemModel> Items { get; set; } = default!;
    }
}
