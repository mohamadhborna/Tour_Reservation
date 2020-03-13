using Tour.Domain.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using Tour.Domain.Interfaces.Service.Core;

namespace Tour.Domain.Interfaces.Service
{
    public interface IPackageService : ICrudService<PackageDto>
    {
        IEnumerable<PackageDto> Search(PackageSearch packageSearch);
    }
}