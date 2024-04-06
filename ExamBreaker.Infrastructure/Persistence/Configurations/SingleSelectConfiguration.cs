using ExamBreaker.Domain.Agggregates.SingleSelects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamBreaker.Infrastructure.Persistence.Configurations;

internal class SingleSelectConfiguration : IEntityTypeConfiguration<SingleSelectQuestion>
{
    public void Configure(EntityTypeBuilder<SingleSelectQuestion> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
