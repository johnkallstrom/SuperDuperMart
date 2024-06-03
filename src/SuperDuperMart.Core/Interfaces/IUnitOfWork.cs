using SuperDuperMart.Core.Entities;

namespace SuperDuperMart.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<User> UserRepository { get; }
        public IRepository<Product> ProductRepository { get; }
        Task SaveAsync();
    }
}
