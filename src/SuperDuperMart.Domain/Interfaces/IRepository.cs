using SuperDuperMart.Domain.Entities;

namespace SuperDuperMart.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> Get();
        T? GetById(int id);
    }
}
