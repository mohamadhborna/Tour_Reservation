using System.Threading.Tasks;
using System.Collections.Generic;
using Tour.Domain.Interfaces;
using Tour.Domain.Interfaces.Service;
using Tour.Domain.Entities;
using Tour.Domain.DTOs;
using System.Linq;
using System;

namespace Tour.Domain.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IDtoMapper<Package, PackageDto> _mapper;
        public PackageService(IPackageRepository packageRepository, IDtoMapper<Package, PackageDto> mapper)
        {
            _packageRepository = packageRepository;
            _mapper = mapper;
        }

        // Add service methods you need in other classes
        public async Task AddAsync(PackageDto package)
        {
            await _packageRepository.AddAsync(_mapper.SingleDtoToEntity(package));
            // await _packageRepository.AddAsync(_mapper.Map<Package>(package));
        }

        public async Task<IEnumerable<PackageDto>> GetAllAsync()
        {
            return _mapper.ListOfEntityToDto(await _packageRepository.GetAllAsync());
            // return _mapper.Map<List<PackageDto>>(await _packageRepository.GetAllAsync());
        }

        public async Task UpdateAsync(PackageDto package)
        {
            await _packageRepository.UpdateAsync(_mapper.SingleDtoToEntity(package));
            // await _packageRepository.UpdateAsync(_mapper.Map<Package>(package));
        }

        public async Task<PackageDto> DeleteAsync(long id)
        {
            return  _mapper.SingleEntityToDto(await _packageRepository.DeleteAsync(id));
            // return _mapper.Map<PackageDto>(await _packageRepository.DeleteAsync(id));
        }

        public IEnumerable<PackageDto> Search(PackageSearch packageSearch)
        {
            var entities = _packageRepository.GetEntitiesAsIQueryable();

            if (packageSearch.OriginCityId != 0){
                entities = entities.Where(e => e.OriginCityId == packageSearch.OriginCityId);
            }

            if (packageSearch.DestinationCityId != 0) {
                entities = entities.Where(e => e.DestinationCityId == packageSearch.DestinationCityId);
            }
            
            if (!packageSearch.FromDate.Equals(default(DateTime)))
            {
                entities = entities.Where(e => e.StartDate >= packageSearch.FromDate);
            }

            if (!packageSearch.ToDate.Equals(default(DateTime)))
            {
                entities = entities.Where(e => e.EndDate <= packageSearch.ToDate);
            }

            IEnumerable<Package> listOfPackages = entities.ToList();

            if (packageSearch.Hotels.Count != 0)
            {
                listOfPackages = listOfPackages.Where(e => e.Hotels.Intersect(packageSearch.Hotels).Any());
            }

            if (packageSearch.Transportations.Count != 0)
            {
                listOfPackages = listOfPackages.Where(e => e.Transportations.Intersect(packageSearch.Transportations).Any());
            }
            
            return _mapper.ListOfEntityToDto(listOfPackages.ToList());
        }
    }
}