namespace SuperDuperMart.Core.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<IEnumerable<CartItem>> GetItemsAsync(Cart cart);
        Task<CartItem?> GetItemByIdAsync(int cartId, int productId);
        Task AddItemAsync(CartItem item);
        void DeleteItem(CartItem item);
        Task<Cart?> GetByUserIdAsync(int userId);
        Task<Cart?> GetByUserIdWithItemsAsync(int userId);
        Task<Cart?> GetByIdWithItemsAsync(int cartId);
    }
}
