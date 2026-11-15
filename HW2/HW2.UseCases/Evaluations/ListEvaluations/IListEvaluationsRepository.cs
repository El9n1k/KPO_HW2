using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Evaluations.ListEvaluations;

public interface IListEvaluationsRepository
{
    IReadOnlyList<Evaluation> GetAllEvaluations();
    IReadOnlyDictionary<Guid, Student> GetAllStudents();
    IReadOnlyDictionary<Guid, Criteria> GetAllCriterias();
}