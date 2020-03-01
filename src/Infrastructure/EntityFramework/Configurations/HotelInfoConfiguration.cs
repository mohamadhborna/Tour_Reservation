using Tour.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tour.Infrastructure.Data.Config
{
    public class HotelInfoConfiguration : BaseConfiguration<HotelInfo>
    {
        public override void Configure(EntityTypeBuilder<HotelInfo> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.Rate)
                .HasDefaultValue(0)
                .HasColumnType("decimal(4, 2)")
                .IsRequired();

            builder.Property(e => e.Stars)
                .HasDefaultValue(0)
                .IsRequired();
                
            builder.HasIndex(e => e.Title)
                .IsUnique()
                .HasName($"UX_{nameof(HotelInfo)}_{nameof(HotelInfo.Title)}");
             
        }
    }
}