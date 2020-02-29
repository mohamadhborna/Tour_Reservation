using Tour.Domain.Entities;
using Tour.Domain.Interfaces;

namespace Tour.Infrastructure.Data
{
    public class PackageRepository : BaseRepository<Package, PackageContext>, IPackageRepository
    {
        public PackageRepository(PackageContext context) : base(context) { }
    }
}