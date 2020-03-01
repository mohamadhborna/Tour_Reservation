using System.Threading.Tasks;
using System.Collections.Generic;
using Tour.Domain.Interfaces;
using Tour.Domain.Interfaces.Service;
using Tour.Domain.Entities;
using Tour.Domain.DTOs;
using AutoMapper;

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
    }
}