using Tour.Domain.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tour.Domain.Interfaces.Service.Core
{
    public interface ICrudService<TDto> 
    where TDto : DtoBase
    {
        Task AddAsync(TDto e);
        Task UpdateAsync(TDto e);
        Task<TDto> DeleteAsync(long id);
        Task<IEnumerable<TDto>> GetAllAsync();
    }
}