using Tour.Domain.Entities;
using Tour.Domain.Interfaces;
using System.Linq;

namespace Tour.Infrastructure.Data
{
    public class PackageRepository : BaseRepository<Package, PackageContext>, IPackageRepository
    {
        public PackageRepository(PackageContext context) : base(context) { }

        public IQueryable<Package> GetEntitiesAsIQueryable()
        {
            return _context.Packages;
        }
    }
}