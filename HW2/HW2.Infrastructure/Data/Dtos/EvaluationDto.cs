namespace HW2.HW2.Infrastructure.Data.Dtos;

public sealed record EvaluationDto(Guid EvaluationId, Guid StudentId, Guid CriteriaId, double Mark);