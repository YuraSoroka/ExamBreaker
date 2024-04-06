using FastEndpoints;

namespace ExamBreaker.API.Endpoints.Hotspots;

public class HotspotByIdRequest
{
    [BindFrom("id")]
    public Guid HotspotId { get; set; }
}
