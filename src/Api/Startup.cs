﻿using System;
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
using Tour.Domain.Interfaces.Repository.Core;
using Microsoft.EntityFrameworkCore.Diagnostics;



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
            services.AddScoped<IRepository<City>, BaseRepository<City, PackageContext>>();
            services.AddScoped<IRepository<HotelInfo>, BaseRepository<HotelInfo, PackageContext>>();
            services.AddScoped<IRepository<TransportationInfo>, BaseRepository<TransportationInfo, PackageContext>>();
            services.AddScoped<IPackageRepository, PackageRepository>();

            services.AddScoped<IPackageService, PackageService>();
            services.AddScoped<ICrudService<City>, CrudServiceBase<City, IRepository<City>>>();
            services.AddScoped<ICrudService<HotelInfo>, CrudServiceBase<HotelInfo, IRepository<HotelInfo>>>();
            services.AddScoped<ICrudService<TransportationInfo>, CrudServiceBase<TransportationInfo, IRepository<TransportationInfo>>>();

            // Uncomment the following line for development and test
            // ConfigureInMemoryDatabase(services);

            ConfigureSqlServer(services);
            ConfigureSwagger(services);

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
