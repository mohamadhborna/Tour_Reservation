using Tour.Domain.Entities;
using Tour.Domain.Interfaces;

namespace Tour.Infrastructure.Data
{
    public class TransportationInfoRepository : BaseRepository<TransportationInfo, PackageContext>, ITransportationInfoRepository
    {
        public TransportationInfoRepository(PackageContext context) : base(context) { }
    }
}