using QuestionOptionEntity = ExamBreaker.Domain.Agggregates.SingleSelects.Entities.QuestionOption;
using FastEndpoints;

namespace ExamBreaker.API.Endpoints.SingleSelect.Mappers;

public class CreateSingleSelectQuestionMapper : Mapper<CreateSingleSelectRequest, object, IEnumerable<QuestionOptionEntity>>
{
    public override IEnumerable<QuestionOptionEntity> ToEntity(CreateSingleSelectRequest request)
    {
        foreach (var option in request.QuestionOptions)
        {
            yield return QuestionOptionEntity.Create(option.Value, option.IsCorrect);
        }
    }
}
