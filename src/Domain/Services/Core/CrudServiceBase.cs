using System.Threading.Tasks;
using System.Collections.Generic;
using Tour.Domain.Interfaces.Service.Core;
using Tour.Domain.Entities;
using Tour.Domain.DTOs;
using Tour.Domain.Interfaces.Repository.Core;
using Tour.Domain.Interfaces;
using Tour.Domain.Core;
using System.Linq;

namespace Tour.Domain.Services
{
    internal class CrudServiceBase<TEntity, TEntityDto, TRepository> : ICrudService<TEntityDto>
        where TEntity : EntityBase
        where TEntityDto : EntityDtoBase
        where TRepository : IRepository<TEntity>
    {
        protected readonly TRepository _repository;
        protected readonly IObjectMapper _mapper;

        public CrudServiceBase(TRepository repository, IObjectMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TEntityDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<TEntityDto>>(await _repository.GetAllAsync());
        }

        public async Task<TEntityDto> AddAsync(TEntityDto entityDto)
        {
            return _mapper.Map<TEntityDto>(await OnAdd(entityDto));
        }


        public async Task<TEntityDto> UpdateAsync(TEntityDto entityDto)
        {
            return _mapper.Map<TEntityDto>(await _repository.UpdateAsync(_mapper.Map<TEntity>(entityDto)));
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                throw new System.Exception($"Entity {typeof(TEntity).Name} With Id {id} Not Found.");

            await OnDelete(entity);
        }

        protected virtual Task<TEntity> OnAdd(TEntityDto entityDto)
        {
            return _repository.AddAsync(_mapper.Map<TEntity>(entityDto));
        }

        protected virtual Task<TEntity> OnUpdate(TEntityDto entityDto)
        {
            return _repository.UpdateAsync(_mapper.Map<TEntity>(entityDto));
        }

        protected virtual Task OnDelete(TEntity entity)
        {
            return _repository.DeleteAsync(entity);
        }

    }

    internal class CrudServiceBase<TEntity, TEntityDto, TSearchModel, TRepository> : CrudServiceBase<TEntity, TEntityDto, TRepository>
        where TEntity : EntityBase
        where TEntityDto : EntityDtoBase
        where TSearchModel : IPagingFilterOptions
        where TRepository : IRepository<TEntity>
    {
        public CrudServiceBase(TRepository repository, IObjectMapper mapper) : base(repository, mapper)
        {
        }

        public IEnumerable<TEntityDto> Search(TSearchModel searchModel)
        {
            var query = OnApplyExplicitFilter(_repository.QueryNoTracking(), searchModel);

            return _mapper.Map<IEnumerable<TEntityDto>>(query.ToList());
        }

        protected virtual IQueryable<TEntity> OnApplyExplicitFilter(IQueryable<TEntity> query, TSearchModel searchModel)
        {
            return query;
        }
    }
}