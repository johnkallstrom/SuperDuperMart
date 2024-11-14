namespace SuperDuperMart.Core.Interfaces
{
    public interface IRoleRepository<TRole> where TRole : IdentityRole<int>
    {
        Task<IEnumerable<TRole>> GetAsync();
        Task<TRole?> GetByIdAsync(int id);
    }
}
