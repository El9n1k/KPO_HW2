using HW2.HW2.Infrastructure.Data.Dtos;
using HW2.HW2.Models;
using HW2.HW2.UseCases.Evaluations.DeleteEvaluation;

namespace HW2.HW2.Infrastructure.Data.Evaluations;

internal sealed class DeleteEvaluationRepository(IDataStorage storage) : IDeleteEvaluationRepository
{
    public Evaluation? GetByEvaluationId(Guid evaluationId)
    {
        StorageDto database = storage.Load();
        return database.Evaluations.TryGetValue(evaluationId, out EvaluationDto? dto)
            ? dto.ToDomain(database.Criterias)
            : null;
    }

    public void DeleteByEvaluationId(Guid evaluationId)
    {
        StorageDto database = storage.Load();
        if (database.Evaluations.Remove(evaluationId))
        {
            storage.Save(database);
        }
    }
}