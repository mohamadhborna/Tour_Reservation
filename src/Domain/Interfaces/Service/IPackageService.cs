using Tour.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Tour.Domain.Interfaces.Service.Core;

namespace Tour.Domain.Interfaces.Service
{
    public interface IPackageService : ICrudService<Package>
    {
    }
}