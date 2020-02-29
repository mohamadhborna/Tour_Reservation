using System;

namespace Tour.Domain.Entities
{
    public class Transportation : EntityBase
    {
<<<<<<< HEAD
        public long TransportationInfoId { get; set; }
        public long PackageId { get; set; }
        public TransportationInfo TransportationInformation { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
=======
        public int TransportationInfoId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
>>>>>>> 3978becef9a42678709e0a2920ef8d89671cdde1
    }
}
