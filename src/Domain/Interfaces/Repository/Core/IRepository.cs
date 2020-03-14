using System.Threading.Tasks;
using Tour.Domain.Entities;

namespace Tour.Domain.Interfaces.Repository.Core
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
         where TEntity : EntityBase
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}