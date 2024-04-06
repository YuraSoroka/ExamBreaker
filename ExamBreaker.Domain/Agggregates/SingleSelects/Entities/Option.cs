namespace ExamBreaker.Domain.Agggregates.SingleSelects.Entities;

public class Option
{
    public int Id { get; private set; }
    public string Value { get; private set; }
    public bool IsCorrect { get; private set; }
}
