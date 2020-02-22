using Tour.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tour.Domain.Interfaces.Service
{
    public interface IHotelInfoService
    {
        Task Create(HotelInfo hotelInfo);
        Task<IReadOnlyList<HotelInfo>> Get();
        Task Update(HotelInfo hotelInfo);
        Task<HotelInfo> Delete(long id);
    }
}