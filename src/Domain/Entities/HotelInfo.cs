using Tour.Domain.Interfaces;

namespace Tour.Domain.Entities
{
    public class HotelInfo : EntityBase
    {
        public string Title { get; set; }
        public int Stars { get; set; }
        public float Rate { get; set; }
        public City city { get; set; }
        public string Location { get; set; }
    }
}
