namespace ExamBreaker.API.Endpoints.SingleSelect;

public record CreateSingleSelectRequest(
    string Question,
    IEnumerable<QuestionOption> QuestionOptions);


public record QuestionOption(string Value, bool IsCorrect);
