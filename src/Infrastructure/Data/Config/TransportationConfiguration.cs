using Tour.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tour.Infrastructure.Data.Config
{
    public class TransformationConfiguration : IEntityTypeConfiguration<Transportation>
    {
        public void Configure(EntityTypeBuilder<Transportation> builder)
        {
            builder.ToTable(nameof(Transportation));

            builder.HasKey(h => h.Id);
        }
    }
}