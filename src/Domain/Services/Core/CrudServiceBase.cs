using System.Threading.Tasks;
using System.Collections.Generic;
using Tour.Domain.Interfaces.Service.Core;
using Tour.Domain.Entities;
using Tour.Domain.DTOs;
using Tour.Domain.Interfaces.Repository.Core;
using Tour.Domain.Interfaces;

namespace Tour.Domain.Services
{
    public class CrudServiceBase<TEntity, TDto, TRepository> : ICrudService<TDto>
    where TEntity : EntityBase
    where TDto : DtoBase
    where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;
        private readonly IDtoMapper<TEntity, TDto> _mapper;

        public CrudServiceBase(TRepository repository, IDtoMapper<TEntity, TDto> mapper)
        {
            _repository = repository;
            _mapper = mapper; 
        }

        // Add service methods you need in other classes
        public async Task AddAsync(TDto e)
        {

            await _repository.AddAsync(_mapper.SingleDtoToEntity(e));
            // await _repository.AddAsync(_mapper.Map<TEntity>(e));
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            return _mapper.ListOfEntityToDto(await _repository.GetAllAsync());
            // return _mapper.Map<List<TDto>>(await _repository.GetAllAsync());
        }

        public async Task UpdateAsync(TDto e)
        {
            await _repository.UpdateAsync(_mapper.SingleDtoToEntity(e));
            // await _repository.UpdateAsync(_mapper.Map<TEntity>(e));
        }

        public async Task<TDto> DeleteAsync(long id)
        { 
            return  _mapper.SingleEntityToDto(await _repository.DeleteAsync(id)); 
            // return  _mapper.Map<TDto>(await _repository.DeleteAsync(id));
        }
    }
}