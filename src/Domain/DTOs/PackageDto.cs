using System;
using System.Collections.Generic;
using Tour.Domain.Interfaces;
using Tour.Domain.Entities;

namespace Tour.Domain.DTOs
{
    public class PackageDto : EntityDtoBase, IAggregateRoot
    {
        public string Title { get; set; }
        public long OriginCityId { get; set; }
        public long DestinationCityId { get; set; }
        public string SupportPhone { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<Hotel> Hotels { get; set; } = new List<Hotel>();
        public IEnumerable<Transportation> Transportations { get; set; } = new List<Transportation>();
    }
}
