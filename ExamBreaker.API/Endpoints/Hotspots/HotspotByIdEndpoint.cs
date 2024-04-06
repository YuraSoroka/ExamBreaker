using FastEndpoints;

namespace ExamBreaker.API.Endpoints.Hotspots;

public class HotspotByIdEndpoint : Endpoint<HotspotByIdRequest, string>
{
    public override void Configure()
    {
        Get("api/hotspots/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(HotspotByIdRequest req, CancellationToken ct)
    {
        await SendAsync("Success", cancellation: ct);
    }
}
