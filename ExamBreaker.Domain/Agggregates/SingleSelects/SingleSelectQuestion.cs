using ExamBreaker.Domain.Agggregates.SingleSelects.Entities;

namespace ExamBreaker.Domain.Agggregates.SingleSelects;

public class SingleSelectQuestion
{
    public Guid Id { get; private set; }
    public string Question { get; private set; }

    public List<Option> Options { get; private set; }

    public SingleSelectQuestion(string question)
    {
        Question = question;
    }
}
