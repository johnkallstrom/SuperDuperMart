﻿using SuperDuperMart.Core.Entities;

namespace SuperDuperMart.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity?> GetByIdAsync(int id);
    }
}