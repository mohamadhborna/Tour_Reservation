using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
using Microsoft.EntityFrameworkCore.Diagnostics;
using Tour.Api.Filters;
using AutoMapper;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRepository<City>, RepositoryBase<City, PackageContext>>();
            services.AddScoped<IRepository<HotelInfo>, RepositoryBase<HotelInfo, PackageContext>>();
            services.AddScoped<IRepository<TransportationInfo>, RepositoryBase<TransportationInfo, PackageContext>>();

            services.AddScoped<IPackageService, PackageService>();

            services.AddScoped<ICrudService<CityDto>, CrudServiceBase<City, CityDto, IRepository<City>>>();
            services.AddScoped<ICrudService<HotelInfoDto>, CrudServiceBase<HotelInfo, HotelInfoDto, IRepository<HotelInfo>>>();
            services.AddScoped<ICrudService<TransportationInfoDto>, CrudServiceBase<TransportationInfo, TransportationInfoDto, IRepository<TransportationInfo>>>();

            services.AddScoped<Tour.Domain.Interfaces.IObjectMapper, DefaultObjectMapper>();

            ConfigureSqlServer(services);
            ConfigureSwagger(services);
            services.AddAutoMapper(typeof(Startup), typeof(MappingProfile));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(GlobalExceptionFilter));
            });
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

        public void ConfigureSqlServer(IServiceCollection services)
        {
            services.AddDbContext<PackageContext>(options =>
                options.UseSqlServer(Configuration["ConnectionString:DefaultConnection"], providerOptions => providerOptions.CommandTimeout(60))
                        .EnableSensitiveDataLogging(Environment.IsDevelopment())
                        .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning))
                        .EnableDetailedErrors()
                        .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll));

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
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger for Tour v1");
            });
            app.UseMvc();
        }
    }
}
