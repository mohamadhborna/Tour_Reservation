using Tour.Domain.Interfaces;

namespace Tour.Domain.Entities
{
    public class TransportationInfo : BaseEntity, IAggregateRoot
    {
        public string CompanyName { get; set; }
        public int Type { get; set; }
    }
}
