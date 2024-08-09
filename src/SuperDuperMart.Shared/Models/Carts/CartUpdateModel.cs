using System.ComponentModel.DataAnnotations;

namespace SuperDuperMart.Shared.Models.Carts
{
    public class CartUpdateModel
    {
        [Required(ErrorMessage = "Please enter a session id")]
        public Guid SessionId { get; set; }

        public bool Purchased { get; set; }

        public List<CartItemAddModel> Items { get; set; } = new();
    }
}
