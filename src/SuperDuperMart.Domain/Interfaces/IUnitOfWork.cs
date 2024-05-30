using SuperDuperMart.Domain.Entities;

namespace SuperDuperMart.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Product> ProductRepository { get; }
        Task SaveAsync();
    }
}
