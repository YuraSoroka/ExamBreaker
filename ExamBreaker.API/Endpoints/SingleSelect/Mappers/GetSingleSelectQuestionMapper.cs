using ExamBreaker.Domain.Agggregates.SingleSelects;
using FastEndpoints;
using QuestionOptionEntity = ExamBreaker.Domain.Agggregates.SingleSelects.Entities.QuestionOption;

namespace ExamBreaker.API.Endpoints.SingleSelect.Mappers;

public class GetSingleSelectQuestionMapper : Mapper<SingleSelectByIdRequest, SingleSelectByIdResponse, SingleSelectQuestion>
{
    public override SingleSelectByIdResponse FromEntity(SingleSelectQuestion e)
    {
        return new SingleSelectByIdResponse
        {
            Id = e.Id.Value,
            Question = e.Question,
            QuestionOptions = MapFromOptions(e.QuestionOptions)
        };
    }

    private IEnumerable<QuestionOptionResponse> MapFromOptions(IEnumerable<QuestionOptionEntity> options)
    {
        foreach (var option in options)
        {
            yield return new QuestionOptionResponse(option.Id.Value, option.Value);
        }
    }
}
