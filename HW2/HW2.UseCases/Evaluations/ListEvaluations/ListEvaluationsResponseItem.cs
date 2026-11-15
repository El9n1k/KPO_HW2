namespace HW2.HW2.UseCases.Evaluations.ListEvaluations;

public sealed record ListEvaluationsResponseItem(Guid EvaluationId,
    Guid StudentId, string Name, string Surname, Guid CriteriaId, string CriteriaName,
    double Mark);