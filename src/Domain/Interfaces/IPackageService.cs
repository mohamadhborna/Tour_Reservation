using Tour.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tour.Domain.Interfaces
{
    public interface IPackageService
    {
        Task Create(Package package);
        Task<IReadOnlyList<Package>> Get();
        Task Update(Package package);
        Task<Package> Delete(long id);
    }
}