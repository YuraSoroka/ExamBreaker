using ExamBreaker.API.Endpoints.SingleSelect.Mappers;
using ExamBreaker.Application.Features.SingleSelect.Commands;
using ExamBreaker.Domain.Agggregates.SingleSelects;
using FastEndpoints;
using MediatR;

namespace ExamBreaker.API.Endpoints.SingleSelect;

public class CreateSingleSelectEndpoint : Endpoint<CreateSingleSelectRequest, SingleSelectQuestion, CreateSingleSelectQuestionMapper>
{
    private readonly ISender _sender;

    public CreateSingleSelectEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Post("api/single-selects");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateSingleSelectRequest request, CancellationToken cancellationToken)
    {
        await SendAsync(
            await _sender.Send(
                new CreateSingleSelectCommand(request.Question, Map.ToEntity(request)), cancellationToken),
            cancellation: cancellationToken);
    }
}
