using Tour.Domain.DTOs;
using Tour.Domain.Interfaces.Service.Core;

namespace Tour.Domain.Interfaces.Service
{
    public interface IPackageService : ICrudService<PackageDto, PackageSearchModel>
    {
    }
}