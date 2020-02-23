using Tour.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tour.Infrastructure.Data.Config
{
    public class HotelInfoConfiguration : IEntityTypeConfiguration<HotelInfo>
    {
        public void Configure(EntityTypeBuilder<HotelInfo> builder)
        {
            builder.ToTable(nameof(HotelInfo));

            builder.HasKey(h => h.Id);
        }
    }
}