using FastEndpoints;

namespace ExamBreaker.API.Endpoints.SingleSelect;

public class SingleSelectByIdRequest
{
    [BindFrom("id")]
    public Guid SingleSelectId { get; set; }
}
