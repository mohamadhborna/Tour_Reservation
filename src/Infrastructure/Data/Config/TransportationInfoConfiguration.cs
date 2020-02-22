using Tour.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tour.Infrastructure.Data.Config
{
    public class TransformationInfoConfiguration : IEntityTypeConfiguration<TransportationInfo>
    {
        public void Configure(EntityTypeBuilder<TransportationInfo> builder)
        {
            builder.ToTable(nameof(TransportationInfo));

            builder.HasKey(h => h.Id);
        }
    }
}