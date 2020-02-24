using System;

namespace Tour.Domain.Entities
{
    public class Transportation : BaseEntity
    {
        public long TransportationInfoId { get; set; }
        public long PackageId { get; set; }
        public TransportationInfo TransportationInformation { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
