using ExamBreaker.Domain.Agggregates.SingleSelects;
using ExamBreaker.Domain.Agggregates.SingleSelects.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamBreaker.Infrastructure.Persistence.Configurations;

internal sealed class SingleSelectConfiguration : IEntityTypeConfiguration<SingleSelectQuestion>
{
    public void Configure(EntityTypeBuilder<SingleSelectQuestion> builder)
    {
        ConfigureSingleSelectQuestionTable(builder);
        ConfigureQuestionOptionsTable(builder);
    }

    private void ConfigureSingleSelectQuestionTable(EntityTypeBuilder<SingleSelectQuestion> builder)
    {
        builder.ToTable("SingleSelectQuestions");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => SingleSelectId.Create(value));
    }

    private void ConfigureQuestionOptionsTable(EntityTypeBuilder<SingleSelectQuestion> builder)
    {
    
        builder.OwnsMany(q => q.QuestionOptions, optionsBuilder =>
        {
            optionsBuilder.ToTable("SingleSelectOptions");
    
            optionsBuilder
                .WithOwner()
                .HasForeignKey("QuestionId");
    
            optionsBuilder.HasKey(x => x.Id);

            optionsBuilder
                .Property(x => x.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => QuestionOptionId.Create(value));
        });
    
        builder.Metadata
            .FindNavigation(nameof(SingleSelectQuestion.QuestionOptions))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
