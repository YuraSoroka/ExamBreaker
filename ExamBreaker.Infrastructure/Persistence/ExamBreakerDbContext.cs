using ExamBreaker.Domain.Agggregates.SingleSelects;
using Microsoft.EntityFrameworkCore;

namespace ExamBreaker.Infrastructure.Persistence;

public class ExamBreakerDbContext : DbContext
{
    public ExamBreakerDbContext(DbContextOptions<ExamBreakerDbContext> options)
        : base(options)
    { }

    public DbSet<SingleSelectQuestion> SingleSelectQuestions => Set<SingleSelectQuestion>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("eb");

        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(ExamBreakerDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
