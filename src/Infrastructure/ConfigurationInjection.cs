using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Tour.Domain.Entities;
using Tour.Domain.Interfaces.Repository.Core;
using Tour.Infrastructure.Data;

[assembly: HostingStartup(typeof(Tour.Infrastructure.ConfigurationInjection))]

namespace Tour.Infrastructure
{
    public class ConfigurationInjection : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services=>{
                services.AddScoped<IRepository<City>, RepositoryBase<City, PackageContext>>();
                services.AddScoped<IRepository<HotelInfo>, RepositoryBase<HotelInfo, PackageContext>>();
                services.AddScoped<IRepository<TransportationInfo>, RepositoryBase<TransportationInfo, PackageContext>>();
                services.AddScoped<IRepository<Package>, RepositoryBase<Package,PackageContext>>();

                services.AddScoped<Tour.Domain.Interfaces.IObjectMapper, DefaultObjectMapper>();

                services.AddAutoMapper(typeof(ConfigurationInjection), typeof(MappingProfile));
            });
        }
    }
}