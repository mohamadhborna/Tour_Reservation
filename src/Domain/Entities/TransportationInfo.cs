using Tour.Domain.Interfaces;

namespace Tour.Domain.Entities
{
    public enum TransportationType{
        Train, 
        Bus, 
        Airplain,
    }
    public class TransportationInfo : BaseEntity
    {
        public string CompanyName { get; set; }
        public TransportationType Type { get; set; }
    }
}
