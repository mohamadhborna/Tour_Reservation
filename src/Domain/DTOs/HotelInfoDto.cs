using Tour.Domain.Interfaces;

namespace Tour.Domain.DTOs
{
    public class HotelInfoDto : DtoBase
    {
        public string Title { get; set; }
        public int Stars { get; set; }
        public float Rate { get; set; }
        public long cityId { get; set; }
        public string Location { get; set; }
    }
}
