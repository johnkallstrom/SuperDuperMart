using System.Linq.Expressions;

namespace SuperDuperMart.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<IEnumerable<TEntity>> GetAsync(IQueryParams parameters);
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity?> GetByIdAsync<TProperty>(int id, Expression<Func<TEntity, TProperty>> include);
        Task<TEntity> CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
