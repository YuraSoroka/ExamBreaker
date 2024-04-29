using ExamBreaker.Application.Common.Interfaces.Persistence;
using ExamBreaker.Domain.Agggregates.SingleSelects;
using ExamBreaker.Domain.Agggregates.SingleSelects.Entities;
using MediatR;

namespace ExamBreaker.Application.Features.SingleSelect.Commands;

public record CreateSingleSelectCommand(
    string Question,
    IEnumerable<QuestionOption> QuestionOptions) : IRequest<SingleSelectQuestion>;

public class CreateSingleSelectCommandHandler : IRequestHandler<CreateSingleSelectCommand, SingleSelectQuestion>
{
    private readonly ISingleSelectRepository _singleSelectRepository;

    public CreateSingleSelectCommandHandler(ISingleSelectRepository singleSelectRepository)
    {
        _singleSelectRepository = singleSelectRepository;
    }

    public Task<SingleSelectQuestion> Handle(CreateSingleSelectCommand request, CancellationToken cancellationToken)
    {
        var singleSelectQuestion = SingleSelectQuestion.Create(
            request.Question,
            request.QuestionOptions.ToList());
        
        _singleSelectRepository.Add(singleSelectQuestion);

        return Task.FromResult(singleSelectQuestion);
    }
}
