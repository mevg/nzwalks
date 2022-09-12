using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NZWalks.API.Entities;

namespace NZWalks.API.Persistence.Configurations
{
    public class WalkDifficultyConfiguration : IEntityTypeConfiguration<WalkDifficulty>
    {
        public void Configure(EntityTypeBuilder<WalkDifficulty> builder)
        {
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Code).IsRequired();
            builder.HasKey(p => p.Id);
        }
    }
}
