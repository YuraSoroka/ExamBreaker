using ExamBreaker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamBreaker.Infrastructure.Persistence.Configurations;

internal class HotspotConfiguration : IEntityTypeConfiguration<Hotspot>
{
    public void Configure(EntityTypeBuilder<Hotspot> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
