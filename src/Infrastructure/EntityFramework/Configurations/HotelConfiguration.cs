using Tour.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tour.Infrastructure.Data.Config
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.ToTable(nameof(Hotel));

            builder.HasKey(h => h.Id);

            builder.Property(h => h.Price)
                    .HasColumnType("decimal(18, 4)");
        }
    }
}