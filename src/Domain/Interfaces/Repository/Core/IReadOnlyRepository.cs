using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tour.Domain.Entities;

namespace Tour.Domain.Interfaces.Repository.Core
{
    public interface IReadOnlyRepository<TEntity> where TEntity : EntityBase
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(long id);
        IQueryable<TEntity> QueryNoTracking(Expression<Func<TEntity, bool>> predicate = null);
    }
}