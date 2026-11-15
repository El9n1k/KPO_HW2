using HW2.HW2.Infrastructure.Data.Dtos;
using HW2.HW2.Models;
using HW2.HW2.UseCases.Evaluations.ImportGradebook;

namespace HW2.HW2.Infrastructure.Data.Evaluations;

internal sealed class ImportGradebookRepository(IDataStorage storage) : IImportGradebookRepository
{
    public void Save(Evaluation evaluation)
    {
        StorageDto database = storage.Load();
        database.Evaluations[evaluation.Id] = evaluation.ToDto();
        storage.Save(database);
    }

    public Criteria? FindCriteriaByName(string criteriaName)
    {
        StorageDto database = storage.Load();

        CriteriaDto? dto = database.Criterias.Values.FirstOrDefault(c =>
            c.Name.Equals(criteriaName, StringComparison.OrdinalIgnoreCase));

        return dto?.ToDomain();
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

    public Student? GetStudentById(Guid studentId)
    {
        StorageDto database = storage.Load();
        return database.Students.TryGetValue(studentId, out StudentDto? dto)
            ? dto.ToDomain()
            : null;
    }
}