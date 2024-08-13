namespace SuperDuperMart.Core.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<IEnumerable<CartItem>> GetCartItemsAsync(int cartId);
        Task<Result> AddItemAsync(int cartId, int productId);
        Task<Cart?> GetByUserIdAsync(int userId);
    }
}
