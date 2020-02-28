using Tour.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tour.Domain.Interfaces.Service.Core
{
    public interface ICrudService<TEntity> where TEntity : EntityBase
    {
        Task AddAsync(TEntity e);
        Task UpdateAsync(TEntity e);
        Task<TEntity> DeleteAsync(long id);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}