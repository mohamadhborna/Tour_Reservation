using System;

namespace Tour.Domain.Entities
{
    public class Transportation : EntityBase
    {
        public int TransportationInfoId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
