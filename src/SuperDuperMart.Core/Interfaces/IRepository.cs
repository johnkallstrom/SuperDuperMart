using SuperDuperMart.Core.Entities;

namespace SuperDuperMart.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
