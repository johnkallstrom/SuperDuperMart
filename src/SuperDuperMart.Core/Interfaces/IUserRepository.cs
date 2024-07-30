namespace SuperDuperMart.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<List<string>> GetUserRolesAsync(User user);
    }
}
