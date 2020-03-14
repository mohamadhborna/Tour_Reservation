using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Tour.Domain.Entities;
using Tour.Domain.Interfaces.Repository.Core;
using System.Linq;
using System.Linq.Expressions;
using System;
using Tour.Infrastructure.Extensions;

namespace Tour.Infrastructure.Data
{
    internal class ReadOnlyRepositoryBase<TEntity, TDbContext> : IReadOnlyRepository<TEntity>
        where TEntity : EntityBase
        where TDbContext : DbContext
    {
        protected readonly TDbContext _dbContext;

        public ReadOnlyRepositoryBase(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();
        protected virtual IQueryable<TEntity> Query => DbSet;

        public Task<List<TEntity>> GetAllAsync()
        {
            return Query.ToListAsync();
        }

        public virtual Task<TEntity> GetByIdAsync(long id)
        {
            return Query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual IQueryable<TEntity> QueryNoTracking(Expression<Func<TEntity, bool>> predicate = null)
        {
            return DbSet.AddPredicate(predicate)
                        .AsNoTracking();
        }
    }
}