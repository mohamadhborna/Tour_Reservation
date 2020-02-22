using System.Threading.Tasks;
using System.Collections.Generic;
using Tour.Domain.Interfaces;
using Tour.Domain.Interfaces.Service;
using Tour.Domain.Entities;

namespace Tour.Domain.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        // Add service methods you need in other classes
        public async Task Create(City city)
        {
            await _cityRepository.CreateAsync(city);
        }

        public async Task<IReadOnlyList<City>> Get()
        {
            return await _cityRepository.GetAllAsync();
        }

        public async Task Update(City city)
        {
            await _cityRepository.UpdateAsync(city);
        }

        public async Task<City> Delete(long id)
        {
            return await _cityRepository.DeleteAsync(id);
        }
    }
}