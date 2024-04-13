using ExamBreaker.Domain.Agggregates.SingleSelects.Entities;
using ExamBreaker.Domain.Agggregates.SingleSelects.ValueObjects;
using ExamBreaker.Domain.Common.Models;

namespace ExamBreaker.Domain.Agggregates.SingleSelects;

public sealed class SingleSelectQuestion : AggregateRoot<SingleSelectId, Guid>
{
    private readonly List<QuestionOption> _questionOptions = new();

    public string Question { get; private set; }

    public IReadOnlyList<QuestionOption> Options => _questionOptions.AsReadOnly();

    private SingleSelectQuestion(
        SingleSelectId id,
        string question,
        List<QuestionOption>? questionOptions)
        : base(id)
    {
        Question = question;
        _questionOptions = questionOptions;
    }

    public static SingleSelectQuestion Create(
        string question,
        List<QuestionOption>? questionOptions = null)
    {
        return new SingleSelectQuestion(
            SingleSelectId.CreateUnique(),
            question,
            questionOptions ?? new());
    }
}
