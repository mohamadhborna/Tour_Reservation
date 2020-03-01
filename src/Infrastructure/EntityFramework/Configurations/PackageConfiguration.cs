using Tour.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tour.Infrastructure.Data.Config
{
    public class PackageConfiguration : BaseConfiguration<Package>
    {
        public override void Configure(EntityTypeBuilder<Package> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(40);

            builder.HasIndex(e => e.Title)
                .IsUnique()
                .HasName($"UX_{nameof(Package)}_{nameof(Package.Title)}");

            builder.HasOne(e => e.OriginCity)
                .WithMany()
                .HasForeignKey(e => e.OriginCityId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName($"FK_{nameof(Package)}_{nameof(Package.OriginCityId)}");
                
            builder.HasOne(e => e.DestinationCity)
                .WithMany()
                .HasForeignKey(e => e.DestinationCityId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName($"FK_{nameof(Package)}_{nameof(Package.DestinationCityId)}");
                 
        }
    }
}