using Tour.Domain.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using Tour.Domain.Core;

namespace Tour.Domain.Interfaces.Service.Core
{
    public interface ICrudService<TEntityDto>
        where TEntityDto : EntityDtoBase
    {
        Task<TEntityDto> AddAsync(TEntityDto entityDto);
        Task<TEntityDto> UpdateAsync(TEntityDto entityDto);
        Task DeleteAsync(long id);
        Task<IEnumerable<TEntityDto>> GetAllAsync();
    }


    public interface ICrudService<TEntityDto, TSearchModel> : ICrudService<TEntityDto>
        where TEntityDto : EntityDtoBase
        where TSearchModel : IPagingFilterOptions
    {
        IEnumerable<TEntityDto> Search(TSearchModel searchModel);
    }
}