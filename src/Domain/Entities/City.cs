using Tour.Domain.Interfaces;

namespace Tour.Domain.Entities
{
    public class City : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
    }
}
