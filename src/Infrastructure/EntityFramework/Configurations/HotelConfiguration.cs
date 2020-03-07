using Tour.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tour.Infrastructure.Data.Config
{
    public class HotelConfiguration : BaseConfiguration<Hotel>
    {
        public override void Configure(EntityTypeBuilder<Hotel> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Price)
                .IsRequired();

            builder.HasOne(e => e.HotelInformation)
                .WithMany()
                .HasForeignKey(e => e.HotelInfoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName($"FK_{nameof(Hotel)}_{nameof(Hotel.HotelInfoId)}");

            builder.HasOne<Package>()
                .WithMany(e => e.Hotels)
                .HasForeignKey(e => e.PackageId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName($"FK_{nameof(Hotel)}_{nameof(Hotel.PackageId)}");

            builder.Property(e => e.Price)
                .HasColumnType("decimal(6,1)");    
        }
    }
}