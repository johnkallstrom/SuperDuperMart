using SuperDuperMart.Core.Entities;

namespace SuperDuperMart.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> Get();
        T? GetById(int id);
    }
}
