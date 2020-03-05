using Tour.Domain.DTOs;
using Tour.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tour.Domain.Interfaces
{
    public interface IDtoMapper<TEntity, TDto>
    where TEntity : EntityBase
    where TDto : DtoBase
    {
        TEntity SingleDtoToEntity(TDto e);
        TDto SingleEntityToDto(TEntity e);
        IEnumerable<TDto> ListOfEntityToDto(IEnumerable<TEntity> eList);

    }
}