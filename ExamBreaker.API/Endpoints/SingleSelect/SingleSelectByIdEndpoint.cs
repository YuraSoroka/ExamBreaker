using ExamBreaker.Application.Features.SingleSelect.Queries;
using FastEndpoints;
using MediatR;

namespace ExamBreaker.API.Endpoints.SingleSelect;

public class SingleSelectByIdEndpoint : Endpoint<SingleSelectByIdRequest, string>
{
    private readonly ISender _sender;

    public SingleSelectByIdEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("api/single-selects/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SingleSelectByIdRequest req, CancellationToken ct)
    {
        await SendAsync(
            await _sender.Send(new GetSingleSelectByIdQuery(req.SingleSelectId), ct),
            cancellation: ct);
    }
}
