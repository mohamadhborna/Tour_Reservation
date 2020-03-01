using Tour.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tour.Infrastructure.Data.Config
{
    public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity: EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            // builder.ToTable(nameof(TEntity));
            // builder.HasKey(e => e.Id)
            //     .HasName($"PK_{nameof(TEntity)}_Id");
        }
    }
}