using ExamBreaker.Domain.Common.Models;

namespace ExamBreaker.Domain.Agggregates.SingleSelects.ValueObjects;

public sealed class SingleSelectId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    public SingleSelectId(Guid value)
    {
        Value = value;
    }

    public static SingleSelectId CreateUnique()
    {
        return new SingleSelectId(Guid.NewGuid());
    }

    public static SingleSelectId Create(Guid value)
    {
        return new SingleSelectId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
