using Tour.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tour.Infrastructure.Data.Config
{
    public class TransportationConfiguration : BaseConfiguration<Transportation>
    {
        public override void Configure(EntityTypeBuilder<Transportation> builder)
        {
            base.Configure(builder);
            
            builder.HasOne(e => e.TransportationInformation)
                .WithMany()
                .HasForeignKey(e => e.TransportationInfoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName($"FK_{nameof(Transportation)}_{nameof(Transportation.TransportationInfoId)}");

            builder.HasOne<Package>()
                .WithMany(e => e.Transportations)
                .HasForeignKey(e => e.PackageId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName($"FK_{nameof(Transportation)}_{nameof(Transportation.PackageId)}");  

            builder.Property(e => e.FromDate)
                .IsRequired();

            builder.Property(e => e.ToDate)
                .IsRequired();
        }
    }
}