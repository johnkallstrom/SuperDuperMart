namespace SuperDuperMart.Core.Interfaces
{
    public interface IUserRepository<TUser> where TUser : IdentityUser<int>
    {
        Task<IEnumerable<TUser>> GetAsync();
        Task<(int Pages, IEnumerable<TUser> Data)> GetPaginatedAsync(int pageNumber, int pageSize);
        Task<TUser?> GetByIdAsync(int id);
        Task<bool> HasCartAsync(User user);
        Task<(bool Succeeded, IEnumerable<string> Errors)> CreateAsync(TUser user, string password);
        Task<(bool Succeeded, IEnumerable<string> Errors)> UpdateAsync(TUser user);
        void Delete(TUser user);
    }
}
