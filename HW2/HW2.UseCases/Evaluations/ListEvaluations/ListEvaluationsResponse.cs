namespace HW2.HW2.UseCases.Evaluations.ListEvaluations;

public sealed record ListEvaluationsResponse(
    IReadOnlyList<ListEvaluationsResponseItem> Evaluations);