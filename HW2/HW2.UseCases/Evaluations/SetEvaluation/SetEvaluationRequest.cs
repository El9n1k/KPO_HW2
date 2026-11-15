namespace HW2.HW2.UseCases.Evaluations.SetEvaluation;

public sealed record SetEvaluationRequest(Guid StudentId, Guid CriteriaId, double Mark);