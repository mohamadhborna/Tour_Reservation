using Tour.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Tour.Domain
{
    public class PackageSearch
    {
        public long OriginCityId { get; set; }
        public long DestinationCityId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
        public ICollection<Transportation> Transportations { get; set; } = new List<Transportation>();
    }
}