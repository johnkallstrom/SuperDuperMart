using System.Linq.Expressions;

namespace SuperDuperMart.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<(int Pages, IEnumerable<TEntity> Data)> GetPaginatedAsync(int pageNumber, int pageSize);
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity?> GetByIdAsync<TProperty>(int id, Expression<Func<TEntity, TProperty>> include);
        Task<TEntity> CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}