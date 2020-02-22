using System.Collections.Generic;
using System.Threading.Tasks;
using Tour.Domain.Entities;

namespace Tour.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        Task CreateAsync(T entity);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task<T> DeleteAsync(long id);
    }
}