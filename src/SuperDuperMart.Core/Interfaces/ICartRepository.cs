namespace SuperDuperMart.Core.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<Cart?> GetByUserIdAsync(int userId);
    }
}
