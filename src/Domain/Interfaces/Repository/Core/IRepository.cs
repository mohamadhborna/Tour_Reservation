using System.Collections.Generic;
using System.Threading.Tasks;
using Tour.Domain.Entities;

namespace Tour.Domain.Interfaces.Repository.Core
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task<T> DeleteAsync(long id);
    }
}