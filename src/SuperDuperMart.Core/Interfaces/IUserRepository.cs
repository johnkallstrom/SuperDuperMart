namespace SuperDuperMart.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAsync();
        Task<User?> GetByIdAsync(int id);
        Task<List<string>> GetRolesAsync(User user);
    }
}
