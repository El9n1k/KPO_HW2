using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Evaluations.CalculateFinalEvaluation;

public interface ICalculateFinalEvaluationRepository
{
    IReadOnlyCollection<Criteria> GetAllCriteria();
    IReadOnlyCollection<Evaluation> GetEvaluations();
}