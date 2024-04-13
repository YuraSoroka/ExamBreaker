using ExamBreaker.Domain.Common.Models;

namespace ExamBreaker.Domain.Agggregates.SingleSelects.ValueObjects;

public sealed class QuestionOptionId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    public QuestionOptionId(Guid value)
    {
        Value = value;
    }

    public static QuestionOptionId CreateUnique()
    {
        return new QuestionOptionId(Guid.NewGuid());
    }

    public static QuestionOptionId Create(Guid value)
    {
        return new QuestionOptionId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
