using System;
using Tour.Domain.Core;

namespace Tour.Domain
{
    public class PackageSearchModel : DateFilterOptions
    {
        public long? OriginCityId { get; set; }
        public long? DestinationCityId { get; set; }
    }
}