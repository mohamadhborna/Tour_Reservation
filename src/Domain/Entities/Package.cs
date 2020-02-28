using System;
using System.Collections.Generic;
using Tour.Domain.Interfaces;

namespace Tour.Domain.Entities
{
    public class Package : EntityBase, IAggregateRoot
    {
        public string Title { get; set; }
        public City OriginCity { get; set; }
        public City DestinationCity { get; set; }
        public string SupportPhone { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
        public ICollection<Transportation> Transportations { get; set; } = new List<Transportation>();
    }
}
