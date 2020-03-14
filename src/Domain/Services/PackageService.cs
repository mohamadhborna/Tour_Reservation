using Tour.Domain.Interfaces;
using Tour.Domain.Interfaces.Service;
using Tour.Domain.Entities;
using Tour.Domain.DTOs;
using System.Linq;
using Tour.Domain.Interfaces.Repository.Core;
using Tour.Domain.Extensions;

namespace Tour.Domain.Services
{
    internal class PackageService : CrudServiceBase<Package, PackageDto, PackageSearchModel, IRepository<Package>>, IPackageService
    {
        public PackageService(IRepository<Package> packageRepository, IObjectMapper mapper) : base(packageRepository, mapper)
        {
        }

        protected override IQueryable<Package> OnApplyExplicitFilter(IQueryable<Package> query, PackageSearchModel searchModel)
        {
            if (searchModel.OriginCityId.HasValue)
            {
                query = query.Where(e => e.OriginCityId == searchModel.OriginCityId);
            }

            if (searchModel.DestinationCityId.HasValue)
            {
                query = query.Where(e => e.DestinationCityId == searchModel.DestinationCityId);
            }

            return query.ApplyDateFilter(searchModel, nameof(Package.StartDate))
                        .ApplyDateFilter(searchModel, nameof(Package.EndDate));
        }
    }
}