using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Evaluations.DeleteEvaluation;

public interface IDeleteEvaluationRepository
{
    Evaluation? GetByEvaluationId(Guid evaluationId);
    void DeleteByEvaluationId(Guid evaluationId);
}