using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tour.Domain.Entities;
using Tour.Domain.Interfaces.Repository.Core;

namespace Tour.Infrastructure.Data
{
    internal class RepositoryBase<TEntity, TDbContext> : ReadOnlyRepositoryBase<TEntity, TDbContext>, IRepository<TEntity>
        where TEntity : EntityBase
        where TDbContext : DbContext
    {

        public RepositoryBase(TDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveAsync();
            return entity;
        }
        public async Task DeleteAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            await SaveAsync();
        }

        public virtual Task<int> SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}