namespace SuperDuperMart.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IRoleRepository<Role> RoleRepository { get; }
        public ILocationRepository LocationRepository { get; }
        public ICartRepository CartRepository { get; }
        public IUserRepository<User> UserRepository { get; }
        public IRepository<ProductCategory> ProductCategoryRepository { get; }
        public IRepository<Product> ProductRepository { get; }
        Task SaveAsync();
    }
}
