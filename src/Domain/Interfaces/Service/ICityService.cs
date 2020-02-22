using Tour.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tour.Domain.Interfaces.Service
{
    public interface ICityService
    {
        Task Create(City city);
        Task<IReadOnlyList<City>> Get();
        Task Update(City city);
        Task<City> Delete(long id);
    }
}