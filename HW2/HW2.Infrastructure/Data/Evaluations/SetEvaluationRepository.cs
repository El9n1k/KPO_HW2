using HW2.HW2.Infrastructure.Data.Dtos;
using HW2.HW2.Models;
using HW2.HW2.UseCases.Evaluations.SetEvaluation;

namespace HW2.HW2.Infrastructure.Data.Evaluations;

internal sealed class SetEvaluationRepository(IDataStorage storage) : ISetEvaluationRepository
{
    public Criteria? GetCriteriaById(Guid criteriaId)
    {
        StorageDto database = storage.Load();
        return database.Criterias.TryGetValue(criteriaId, out CriteriaDto? dto)
            ? dto.ToDomain()
            : null;
    }

    public Evaluation? Find(Guid studentId, Guid criteriaId)
    {
        StorageDto database = storage.Load();
        foreach (var evaluation in database.Evaluations)
        {
            if (evaluation.Value.StudentId == studentId && evaluation.Value.CriteriaId == criteriaId)
            {
                return evaluation.Value.ToDomain(database.Criterias);
            }
        }
        return null;
    }

    public void Save(Evaluation evaluation)
    {
        StorageDto database = storage.Load();
        database.Evaluations[evaluation.Id] = evaluation.ToDto();
        storage.Save(database);
    }

    public Student? GetStudentById(Guid studentId)
    {
        StorageDto database = storage.Load();
        return database.Students.TryGetValue(studentId, out StudentDto? dto)
            ? dto.ToDomain()
            : null;
    }
}