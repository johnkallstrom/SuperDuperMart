﻿using SuperDuperMart.Core.Entities.Identity;

namespace SuperDuperMart.Core.Interfaces
{
    public interface IUserRepository<TUser> where TUser : IdentityUser<int>
    {
        Task<IEnumerable<TUser>> GetAsync();
        Task<(int Pages, IEnumerable<TUser> Data)> GetPaginatedAsync(int pageNumber, int pageSize);
        Task<TUser?> GetByIdAsync(int id);
        Task<bool> HasCartAsync(User user);
        bool DoPasswordsMatch(string password, string confirmPassword);
        Task<TUser> CreateAsync(TUser user);
        void Update(TUser user);
        void Delete(TUser user);
    }
}
