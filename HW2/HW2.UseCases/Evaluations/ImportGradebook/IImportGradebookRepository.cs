using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Evaluations.ImportGradebook;

public interface IImportGradebookRepository
{
    void Save(Evaluation evaluation);
    Criteria? FindCriteriaByName(string criteriaName);
    Evaluation? Find(Guid studentId, Guid criteriaId);
    Student? GetStudentById(Guid studentId);
}