using Tour.Domain.Interfaces;

namespace Tour.Domain.Entities
{
    public class HotelInfo : BaseEntity, IAggregateRoot
    {
        public string Title { get; set; }
        public int Stars { get; set; }
        public float Rate { get; set; }
    }
}
