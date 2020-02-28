using System.Collections.Generic;
using System.Threading.Tasks;
using Tour.Domain.Entities;

namespace Tour.Domain.Interfaces.Repository.Core
{
    public interface IRepository<T> where T : EntityBase
    {
        Task AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task<T> DeleteAsync(long id);
    }
}