using System.Threading.Tasks;
using System.Collections.Generic;
using Tour.Domain.Interfaces;
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
        public async Task Create(Package package)
        {
            await _packageRepository.CreateAsync(package);
        }

        public async Task<IReadOnlyList<Package>> Get()
        {
            return await _packageRepository.GetAllAsync();
        }

        public async Task Update(Package package)
        {
            await _packageRepository.UpdateAsync(package);
        }

        public async Task<Package> Delete(long id)
        {
            return await _packageRepository.DeleteAsync(id);
        }
    }
}