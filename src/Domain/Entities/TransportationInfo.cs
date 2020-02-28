using Tour.Domain.Interfaces;

namespace Tour.Domain.Entities
{
    public enum TransportationType{
        Train, 
        Bus, 
        Airplain,
    }
    public class TransportationInfo : EntityBase
    {
        public string CompanyName { get; set; }
        public TransportationType Type { get; set; }
    }
}
