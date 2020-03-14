using AutoMapper;
using Tour.Domain.Entities;
using Tour.Domain.DTOs;

namespace Tour.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDto>();
            CreateMap<HotelInfo, HotelInfoDto>();
            CreateMap<TransportationInfo, TransportationInfoDto>();
            CreateMap<Package, PackageDto>();



            CreateMap<CityDto, City>();
            CreateMap<HotelInfoDto, HotelInfo>();
            CreateMap<TransportationInfoDto, TransportationInfo>();
            CreateMap<PackageDto, Package>();
        }
    }
}