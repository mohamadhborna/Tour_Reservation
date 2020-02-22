using Tour.Domain.Entities;
using Tour.Domain.Interfaces;

namespace Tour.Infrastructure.Data
{
    public class CityRepository : BaseRepository<City, PackageContext>, ICityRepository
    {
        public CityRepository(PackageContext context) : base(context) { }
    }
}