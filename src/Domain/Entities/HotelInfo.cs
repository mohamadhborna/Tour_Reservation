using Tour.Domain.Interfaces;

namespace Tour.Domain.Entities
{
    public class HotelInfo : BaseEntity
    {
        public string Name { get; set; }
        public int Stars { get; set; }
        public float Rate { get; set; }
        public City city { get; set; }
        public string Location { get; set; }
    }
}
