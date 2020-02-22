using Tour.Domain.Entities;
using Tour.Domain.Interfaces;

namespace Tour.Infrastructure.Data
{
    public class HotelInfoRepository : BaseRepository<HotelInfo, PackageContext>, IHotelInfoRepository
    {
        public HotelInfoRepository(PackageContext context) : base(context) { }
    }
}