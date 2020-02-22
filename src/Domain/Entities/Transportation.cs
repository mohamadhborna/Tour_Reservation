using System;

namespace Tour.Domain.Entities
{
    public class Transportation : BaseEntity
    {
        public int TransportationInfoId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
