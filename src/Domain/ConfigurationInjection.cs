using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Tour.Domain.Interfaces.Service;
using Tour.Domain.Interfaces.Service.Core;
using Tour.Domain.Services;
using Tour.Domain.DTOs;
using Tour.Domain.Entities;
using Tour.Domain.Interfaces.Repository.Core;

[assembly: HostingStartup(typeof(Tour.Domain.ConfigurationInjection))]

namespace Tour.Domain
{
    public class ConfigurationInjection : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services=>{
                services.AddScoped<IPackageService, PackageService>();
                services.AddScoped<ICrudService<CityDto>, CrudServiceBase<City, CityDto, IRepository<City>>>();
                services.AddScoped<ICrudService<HotelInfoDto>, CrudServiceBase<HotelInfo, HotelInfoDto, IRepository<HotelInfo>>>();
                services.AddScoped<ICrudService<TransportationInfoDto>, CrudServiceBase<TransportationInfo, TransportationInfoDto, IRepository<TransportationInfo>>>();


            });
        }
    }
}