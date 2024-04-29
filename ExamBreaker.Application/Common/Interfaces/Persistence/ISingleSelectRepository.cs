using ExamBreaker.Domain.Agggregates.SingleSelects;
using ExamBreaker.Domain.Agggregates.SingleSelects.ValueObjects;

namespace ExamBreaker.Application.Common.Interfaces.Persistence;

public interface ISingleSelectRepository
{
    SingleSelectQuestion? GetById(SingleSelectId id);
    void Add(SingleSelectQuestion singleSelectQuestion);
    SingleSelectQuestion Update();
    void Delete(SingleSelectQuestion id);
}
