using Tour.Domain.DTOs;
using Tour.Domain.Entities;
using System.Collections.Generic;
using Tour.Domain.Interfaces; 
using AutoMapper; 

namespace Tour.Infrastructure
{
    public class DtoMapper<TEntity, TDto> : IDtoMapper<TEntity, TDto>
    where TEntity : EntityBase
    where TDto : DtoBase
    {
        private readonly IMapper _mapper;

        public DtoMapper(IMapper mapper) { 
            _mapper = mapper;
        }


        public IEnumerable<TDto> ListOfEntityToDto(IEnumerable<TEntity> eList)
        {
            return  _mapper.Map<List<TDto>>(eList);
        }

        public TEntity SingleDtoToEntity(TDto e)
        {
            return _mapper.Map<TEntity>(e);
        }

        public TDto SingleEntityToDto(TEntity e)
        {
            return  _mapper.Map<TDto>(e);
        }
    }
}