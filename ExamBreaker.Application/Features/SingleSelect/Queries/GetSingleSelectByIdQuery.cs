using ExamBreaker.Application.Common.Interfaces.Persistence;
using ExamBreaker.Domain.Agggregates.SingleSelects;
using ExamBreaker.Domain.Agggregates.SingleSelects.ValueObjects;
using MediatR;

namespace ExamBreaker.Application.Features.SingleSelect.Queries;

public record GetSingleSelectByIdQuery(Guid Id) : IRequest<SingleSelectQuestion?>;

public class GetSingleSelectByIdQueryHandler : IRequestHandler<GetSingleSelectByIdQuery, SingleSelectQuestion?>
{
    private readonly ISingleSelectRepository _singleSelectRepository;

    public GetSingleSelectByIdQueryHandler(ISingleSelectRepository singleSelectRepository)
    {
        _singleSelectRepository = singleSelectRepository;
    }

    public async Task<SingleSelectQuestion?> Handle(GetSingleSelectByIdQuery request, CancellationToken cancellationToken)
    {
        var singleSelectId = SingleSelectId.Create(request.Id);
        return _singleSelectRepository.GetById(singleSelectId);
    }
}
