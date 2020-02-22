using System.Threading.Tasks;
using System.Collections.Generic;
using Tour.Domain.Interfaces;
using Tour.Domain.Interfaces.Service;
using Tour.Domain.Entities;

namespace Tour.Domain.Services
{
    public class HotelInfoService : IHotelInfoService
    {
        private readonly IHotelInfoRepository _hotelInfoRepository;

        public HotelInfoService(IHotelInfoRepository hotelInfoRepository)
        {
            _hotelInfoRepository = hotelInfoRepository;
        }

        // Add service methods you need in other classes
        public async Task Create(HotelInfo hotelInfo)
        {
            await _hotelInfoRepository.CreateAsync(hotelInfo);
        }

        public async Task<IReadOnlyList<HotelInfo>> Get()
        {
            return await _hotelInfoRepository.GetAllAsync();
        }

        public async Task Update(HotelInfo hotelInfo)
        {
            await _hotelInfoRepository.UpdateAsync(hotelInfo);
        }

        public async Task<HotelInfo> Delete(long id)
        {
            return await _hotelInfoRepository.DeleteAsync(id);
        }
    }
}