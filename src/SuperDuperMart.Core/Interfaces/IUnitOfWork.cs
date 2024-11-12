namespace SuperDuperMart.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IRoleRepository<Role> RoleRepository { get; set; }
        public ILocationRepository LocationRepository { get; set; }
        public ICartRepository CartRepository { get; }
        public IUserRepository<User> UserRepository { get; }
        public IPaginatedRepository<Product> ProductRepository { get; }
        Task SaveAsync();
    }
}
