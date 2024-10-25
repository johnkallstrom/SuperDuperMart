namespace SuperDuperMart.Core.Interfaces
{
    public interface IPaginatedRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<(int Pages, IEnumerable<TEntity> Data)> GetPaginatedAsync(int pageNumber, int pageSize);
    }
}
