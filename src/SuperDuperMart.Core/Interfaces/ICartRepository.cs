namespace SuperDuperMart.Core.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task AddItemAsync(CartItem item);
        Task<Cart?> GetByUserIdAsync(int userId);
    }
}
