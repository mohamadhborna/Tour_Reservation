using Tour.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tour.Infrastructure.Data.Config
{
    public class TransportationInfoConfiguration : BaseConfiguration<TransportationInfo>
    {
        public override void Configure(EntityTypeBuilder<TransportationInfo> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.CompanyName)
                .HasMaxLength(40)
                .IsRequired();
            builder.HasIndex(e => e.CompanyName)
                .IsUnique()
                .HasName($"UX_{nameof(TransportationInfo)}_{nameof(TransportationInfo.CompanyName)}");
            builder.Property(e => e.Type)
                .IsRequired();

            
        }
    }
}