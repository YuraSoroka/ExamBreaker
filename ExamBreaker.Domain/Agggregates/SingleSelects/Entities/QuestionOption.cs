using ExamBreaker.Domain.Agggregates.SingleSelects.ValueObjects;
using ExamBreaker.Domain.Common.Models;

namespace ExamBreaker.Domain.Agggregates.SingleSelects.Entities;

public sealed class QuestionOption : Entity<QuestionOptionId>
{
    public string Value { get; private set; }
    public bool IsCorrect { get; private set; }
    
    private QuestionOption(QuestionOptionId optionId, string value, bool isCorrect) 
        : base(optionId)
    {
        Value = value;
        IsCorrect = isCorrect;
    }

    public static QuestionOption Create( string value, bool isCorrect)
    {
        return new QuestionOption(QuestionOptionId.CreateUnique(), value, isCorrect);
    }
}
