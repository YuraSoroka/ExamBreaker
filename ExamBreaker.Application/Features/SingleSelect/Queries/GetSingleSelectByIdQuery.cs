using MediatR;

namespace ExamBreaker.Application.Features.SingleSelect.Queries;

public record GetSingleSelectByIdQuery(Guid Id) : IRequest<string>;

public class GetSingleSelectByIdQueryHandler : IRequestHandler<GetSingleSelectByIdQuery, string>
{
    public Task<string> Handle(GetSingleSelectByIdQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(request.Id.ToString());
    }
}
