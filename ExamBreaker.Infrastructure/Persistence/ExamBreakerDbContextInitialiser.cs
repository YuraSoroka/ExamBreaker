using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ExamBreaker.Infrastructure.Persistence;


public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ExamBreakerDbContextInitialiser>();

        await initialiser.InitialiseAsync();
    }
}


internal class ExamBreakerDbContextInitialiser
{
    private readonly ILogger<ExamBreakerDbContextInitialiser> _logger;
    private readonly ExamBreakerDbContext _context;
    public ExamBreakerDbContextInitialiser(
        ILogger<ExamBreakerDbContextInitialiser> logger,
        ExamBreakerDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }
}
