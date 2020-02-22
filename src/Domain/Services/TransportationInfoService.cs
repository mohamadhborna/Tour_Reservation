using System.Threading.Tasks;
using System.Collections.Generic;
using Tour.Domain.Interfaces;
using Tour.Domain.Interfaces.Service;
using Tour.Domain.Entities;

namespace Tour.Domain.Services
{
    public class TransportationInfoService : ITransportationInfoService
    {
        private readonly ITransportationInfoRepository _transportationInfoRepository;

        public TransportationInfoService(ITransportationInfoRepository transportationInfoRepository)
        {
            _transportationInfoRepository = transportationInfoRepository;
        }

        // Add service methods you need in other classes
        public async Task Create(TransportationInfo transportationInfo)
        {
            await _transportationInfoRepository.CreateAsync(transportationInfo);
        }

        public async Task<IReadOnlyList<TransportationInfo>> Get()
        {
            return await _transportationInfoRepository.GetAllAsync();
        }

        public async Task Update(TransportationInfo transportationInfo)
        {
            await _transportationInfoRepository.UpdateAsync(transportationInfo);
        }

        public async Task<TransportationInfo> Delete(long id)
        {
            return await _transportationInfoRepository.DeleteAsync(id);
        }
    }
}