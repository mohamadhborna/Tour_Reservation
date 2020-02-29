namespace Tour.Domain.Entities
{
    public class Hotel : EntityBase
    {
        public long HotelInfoId { get; set; }
        public long PackageId { get; set; }
        public HotelInfo HotelInformation { get; set; }
        public decimal Price { get; set; }

    }
}
