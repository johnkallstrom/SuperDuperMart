namespace SuperDuperMart.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public ICartRepository CartRepository { get; }
        public IUserRepository UserRepository { get; }
        public IRepository<Product> ProductRepository { get; }
        Task SaveAsync();
    }
}
