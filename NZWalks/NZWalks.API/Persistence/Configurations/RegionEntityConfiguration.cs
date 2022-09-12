using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NZWalks.API.Entities;

namespace NZWalks.API.Persistence.Configurations
{
    public class RegionEntityConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Area).IsRequired();
            builder.Property(p => p.Code).IsRequired();
            builder.Property(p => p.Lat).IsRequired();
            builder.Property(p => p.Long).IsRequired();
            builder.Property(p => p.Population).IsRequired();

            builder.HasKey(p => p.Id);
        }
    }
}
