using System.Reflection;
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
            
            builder.ApplyConfigurationsFromAssembly(typeof(BaseConfiguration<EntityBase>).Assembly);
            
        }
    }
}
