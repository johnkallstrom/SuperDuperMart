using SuperDuperMart.Core.Entities.Identity;

namespace SuperDuperMart.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public ICartRepository CartRepository { get; }
        public IUserRepository<User> UserRepository { get; }
        public IRepository<Product> ProductRepository { get; }
        Task SaveAsync();
    }
}
