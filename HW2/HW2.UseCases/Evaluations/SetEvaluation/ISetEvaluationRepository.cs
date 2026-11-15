using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Evaluations.SetEvaluation;

public interface ISetEvaluationRepository
{
    Criteria? GetCriteriaById(Guid criteriaId);
    Evaluation? Find(Guid studentId, Guid criteriaId);
    void Save(Evaluation evaluation);
    Student? GetStudentById(Guid studentId);
}