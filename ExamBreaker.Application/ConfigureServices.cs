using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ExamBreaker.Application;

public static class ConfigureServices
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

        return services;
    }
}
