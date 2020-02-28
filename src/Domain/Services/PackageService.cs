using System.Threading.Tasks;
using System.Collections.Generic;
using Tour.Domain.Interfaces;
using Tour.Domain.Interfaces.Service;
using Tour.Domain.Entities;

namespace Tour.Domain.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;

        public PackageService(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        // Add service methods you need in other classes
        public async Task AddAsync(Package package)
        {
            await _packageRepository.AddAsync(package);
        }

        public async Task<IEnumerable<Package>> GetAllAsync()
        {
            return await _packageRepository.GetAllAsync();
        }

        public async Task UpdateAsync(Package package)
        {
            await _packageRepository.UpdateAsync(package);
        }

        public async Task<Package> DeleteAsync(long id)
        {
            return await _packageRepository.DeleteAsync(id);
        }
    }
}