using FastEndpoints;
using FastEndpoints.Swagger;

namespace ExamBreaker.API;

public static class ConfigureServices
{
    public static IServiceCollection RegisterWebApiServices(this IServiceCollection services)
    {
        services
            .AddFastEndpoints()
            .SwaggerDocument(opt => opt.AutoTagPathSegmentIndex = 2);

        return services;
    }
}
