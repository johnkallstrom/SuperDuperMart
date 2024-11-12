namespace SuperDuperMart.Core.Interfaces
{
    public interface IRoleRepository<TRole> where TRole : IdentityRole<int>
    {
        Task<IEnumerable<TRole>> GetAsync();
    }
}
