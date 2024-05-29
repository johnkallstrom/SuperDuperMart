using SuperDuperMart.Core.Entities;

namespace SuperDuperMart.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Product> ProductRepository { get; }
        Task SaveAsync();
    }
}
