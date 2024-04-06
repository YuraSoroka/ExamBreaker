using FastEndpoints;
using FastEndpoints.Swagger;

namespace ExamBreaker.API;

public static class ConfigureServices
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services)
    {
        services
            .AddFastEndpoints()
            .SwaggerDocument();

        return services;
    }
}
