using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NZWalks.API.Entities;

namespace NZWalks.API.Persistence.Configurations
{
    public class WalkConfiguration : IEntityTypeConfiguration<Walk>
    {
        public void Configure(EntityTypeBuilder<Walk> builder)
        {
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Length).IsRequired();
            builder.HasOne(p => p.Region);
            builder.HasOne(p => p.WalkDifficulty);
            builder.HasKey(p => p.Id);
        }
    }
}
