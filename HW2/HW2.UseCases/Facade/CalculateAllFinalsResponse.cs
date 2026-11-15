namespace HW2.HW2.UseCases.Facade;

public sealed record CalculateAllFinalsResponse(
    IReadOnlyList<StudentFinalEvaluation> Finals,
    IReadOnlyList<string> Errors);