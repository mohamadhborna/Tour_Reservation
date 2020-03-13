using Tour.Domain.Interfaces.Repository.Core;
using Tour.Domain.Entities;
using System.Linq;

namespace Tour.Domain.Interfaces
{
    public interface IPackageRepository : IRepository<Package> { 
        IQueryable<Package> GetEntitiesAsIQueryable();
    }
}