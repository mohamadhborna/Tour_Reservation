using System.Threading.Tasks;
using System.Collections.Generic;
using Tour.Domain.Interfaces.Service.Core;
using Tour.Domain.Entities;
using Tour.Domain.Interfaces.Repository.Core;

namespace Tour.Domain.Services
{
    public class CrudServiceBase<TEntity, TRepository> : ICrudService<TEntity>
    where TEntity : EntityBase
    where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;

        public CrudServiceBase(TRepository repository)
        {
            _repository = repository;
        }

        // Add service methods you need in other classes
        public async Task AddAsync(TEntity e)
        {
            await _repository.AddAsync(e);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task UpdateAsync(TEntity e)
        {
            await _repository.UpdateAsync(e);
        }

        public async Task<TEntity> DeleteAsync(long id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}