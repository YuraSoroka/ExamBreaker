using FastEndpoints;

namespace ExamBreaker.API.Endpoints.SingleSelect;

public record SingleSelectByIdRequest
{
    [BindFrom("id")]
    public Guid SingleSelectId { get; set; }
}

public record SingleSelectByIdResponse
{
    public Guid Id { get; set; }
    public string Question { get; set; } = null!;
    public IEnumerable<QuestionOptionResponse> QuestionOptions { get; init; } = null!;
}

public record QuestionOptionResponse(Guid Id, string Value);
