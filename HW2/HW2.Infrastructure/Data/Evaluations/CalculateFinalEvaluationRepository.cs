using HW2.HW2.Infrastructure.Data.Dtos;
using HW2.HW2.Models;
using HW2.HW2.UseCases.Evaluations.CalculateFinalEvaluation;

namespace HW2.HW2.Infrastructure.Data.Evaluations;

internal sealed class CalculateFinalEvaluationRepository(IDataStorage storage) : ICalculateFinalEvaluationRepository
{
    public IReadOnlyCollection<Criteria> GetAllCriteria()
    {
        StorageDto database = storage.Load();
        List<Criteria> criterias = [];
        foreach (var criteria in database.Criterias)
        {
            criterias.Add(criteria.Value.ToDomain());
        }
        return criterias;
    }

    public IReadOnlyCollection<Evaluation> GetEvaluations()
    {
        StorageDto database = storage.Load();
        List<Evaluation> evaluations = [];
        foreach (var evaluation in database.Evaluations)
        {
            evaluations.Add(evaluation.Value.ToDomain(database.Criterias));
        }
        return evaluations;
    }
}