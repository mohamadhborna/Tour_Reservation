using System.Threading.Tasks;
using System.Collections.Generic;
using Tour.Domain.Interfaces.Service.Core;
using Tour.Domain.Entities;
using Tour.Domain.Interfaces.Repository.Core;

namespace Tour.Domain.Services
{
    public class BaseService<E, R> : IService<E> 
    where E : BaseEntity 
    where R : IRepository<E>
    {
        private readonly R _repository;

        public BaseService(R repository)
        {
            _repository = repository;
        }

        // Add service methods you need in other classes
        public async Task Create(E e)
        {
            await _repository.CreateAsync(e);
        }

        public async Task<IReadOnlyList<E>> Get()
        {
            return await _repository.GetAllAsync();
        }

        public async Task Update(E e)
        {
            await _repository.UpdateAsync(e);
        }

        public async Task<E> Delete(long id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}