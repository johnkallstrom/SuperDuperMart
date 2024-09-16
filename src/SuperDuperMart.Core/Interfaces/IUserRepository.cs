namespace SuperDuperMart.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAsync();
        Task<(IEnumerable<User> Users, int Pages)> GetPaginatedAsync(int currentPage, int pageSize);
        Task<User?> GetByIdAsync(int id);
        Task<List<string>> GetRolesAsync(User user);
        Task<bool> HasCartAsync(User user);
    }
}
