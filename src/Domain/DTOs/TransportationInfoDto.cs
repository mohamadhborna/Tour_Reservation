using Tour.Domain.Interfaces;
using Tour.Domain.Entities;

namespace Tour.Domain.DTOs
{
    public class TransportationInfoDto : EntityDtoBase
    {
        public string CompanyName { get; set; }
        public TransportationType Type { get; set; }
    }
}
