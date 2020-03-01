using System;
using Microsoft.EntityFrameworkCore;
using Tour.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tour.Infrastructure.Data.Config;

namespace Tour.Infrastructure.Data
{
    public class PackageContext : DbContext
    {
        public DbSet<HotelInfo> HotelInfos { get; set; }
        public DbSet<TransportationInfo> TransportationInfos { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Package> Packages { get; set; }
        public PackageContext(DbContextOptions<PackageContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CityConfiguration());
           
            builder.ApplyConfiguration(new HotelInfoConfiguration());
           
            builder.ApplyConfiguration(new TransportationInfoConfiguration());
            
            builder.ApplyConfiguration(new PackageConfiguration());
            
            builder.ApplyConfiguration(new HotelConfiguration());
        
            builder.ApplyConfiguration(new TransportationConfiguration());
         
        }
    }
}
