using Tour.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tour.Domain.Interfaces.Service.Core
{
    public interface IService<E> where E : BaseEntity
    {
        Task Create(E e);
        Task<IReadOnlyList<E>> Get();
        Task Update(E e);
        Task<E> Delete(long id);
    }
}