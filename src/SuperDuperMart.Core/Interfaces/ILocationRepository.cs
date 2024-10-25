namespace SuperDuperMart.Core.Interfaces
{
    public interface ILocationRepository : IRepository<Location>
    {
        Task<Location?> GetByUserIdAsync(int userId); 
    }
}
