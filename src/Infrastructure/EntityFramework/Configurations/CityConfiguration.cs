using System;
using Tour.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tour.Infrastructure.Data.Config
{
    public class CityConfiguration : BaseConfiguration<City>
    {
        public override void Configure(EntityTypeBuilder<City> builder)
        {
            base.Configure(builder);
            
            builder.HasIndex(e => e.Title)
                .IsUnique()
                .HasName($"UX_{nameof(City)}_{nameof(City.Title)}");

            builder.Property (e => e.Title)
                .IsRequired() 
                .HasMaxLength(40);
                Console.WriteLine("#################---------------------------------->City configuration Applied");
        }
    }
}