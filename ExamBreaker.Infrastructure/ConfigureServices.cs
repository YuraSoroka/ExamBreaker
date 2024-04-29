using ExamBreaker.Application.Common.Interfaces.Persistence;
using ExamBreaker.Infrastructure.Persistence;
using ExamBreaker.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExamBreaker.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ExamBreakerDbContext>((sp, options) =>
        {
            options.UseSqlServer(
                connectionString,
                opt =>
                {
                    opt.MigrationsAssembly(typeof(ExamBreakerDbContext).Assembly.FullName);
                    opt.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "eb");
                }
            );
        });

        services.AddScoped<ExamBreakerDbContextInitialiser>();

        services.RegisterRepositories();

        return services;
    }

    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISingleSelectRepository, SingleSelectRepository>();

        return services;
    }
}
