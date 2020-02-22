using Tour.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tour.Domain.Interfaces.Service
{
    public interface ITransportationInfoService
    {
        Task Create(TransportationInfo transportationInfo);
        Task<IReadOnlyList<TransportationInfo>> Get();
        Task Update(TransportationInfo transportationInfo);
        Task<TransportationInfo> Delete(long id);
    }
}