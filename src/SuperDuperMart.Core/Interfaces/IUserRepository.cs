namespace SuperDuperMart.Core.Interfaces
{
    public interface IUserRepository<TUser> where TUser : IdentityUser<int>
    {
        Task<IEnumerable<TUser>> GetAsync();
        Task<PagedList<TUser>> GetAsync(IQueryParams parameters);
        Task<TUser?> GetByIdAsync(int id);
        Task<string?> AuthenticateAsync(string email, string password);
        Task<bool> HasCartAsync(User user);
        Task<Role?> GetPrimaryRoleAsync(User user);
        Task<IEnumerable<Role>> GetRolesAsync(User user);
        Task AddToRoleAsync(User user, string role);
        Task<(bool Succeeded, IEnumerable<string> Errors)> ClearRolesAsync(User user);
        Task<(bool Succeeded, IEnumerable<string> Errors)> CreateAsync(TUser user, string password);
        Task<(bool Succeeded, IEnumerable<string> Errors)> UpdateAsync(TUser user);
        Task<(bool Succeeded, IEnumerable<string> Errors)> DeleteAsync(TUser user);
    }
}
