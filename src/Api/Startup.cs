using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tour.Domain.Interfaces;
using Tour.Domain.Interfaces.Service;
using Tour.Domain.Interfaces.Service.Core;
using Tour.Domain.Services;
using Tour.Infrastructure;
using Tour.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Tour.Domain.Entities;
using Tour.Domain.DTOs;
using Tour.Domain.Interfaces.Repository.Core;
using AutoMapper;


namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRepository<City>, BaseRepository<City, PackageContext>>();
            services.AddScoped<IRepository<HotelInfo>, BaseRepository<HotelInfo, PackageContext>>();
            services.AddScoped<IRepository<TransportationInfo>, BaseRepository<TransportationInfo, PackageContext>>();
            services.AddScoped<IPackageRepository, PackageRepository>();

            services.AddScoped<IPackageService, PackageService>();
            services.AddScoped<ICrudService<CityDto>, CrudServiceBase<City, CityDto, IRepository<City>>>();
            services.AddScoped<ICrudService<HotelInfoDto>, CrudServiceBase<HotelInfo, HotelInfoDto, IRepository<HotelInfo>>>();
            services.AddScoped<ICrudService<TransportationInfoDto>, CrudServiceBase<TransportationInfo, TransportationInfoDto, IRepository<TransportationInfo>>>();

            services.AddScoped<IDtoMapper<Package, PackageDto> , DtoMapper<Package, PackageDto>>();
            services.AddScoped<IDtoMapper<City, CityDto> , DtoMapper<City, CityDto>>();
            services.AddScoped<IDtoMapper<TransportationInfo, TransportationInfoDto> , DtoMapper<TransportationInfo, TransportationInfoDto>>();
            services.AddScoped<IDtoMapper<HotelInfo, HotelInfoDto> , DtoMapper<HotelInfo, HotelInfoDto>>();

            ConfigureInMemoryDatabase(services);
            ConfigureSwagger(services);
            services.AddAutoMapper(typeof(Startup), typeof(AutoMapping) );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger for Tour", Version = "v1" });
            });
        }

        public void ConfigureInMemoryDatabase(IServiceCollection services)
        {
            services.AddDbContext<PackageContext>(options =>
            {
                options.UseInMemoryDatabase("tour");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger for Tour v1");
            });
        }
    }
}
