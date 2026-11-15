using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Evaluations.ListEvaluations;

internal static class EvaluationMapper
{
    public static ListEvaluationsResponseItem ToDto(this Evaluation evaluation, string name, 
        string surname, string criteriaName)
    {
        return new ListEvaluationsResponseItem(evaluation.Id, evaluation.StudentId, name, surname, evaluation.CriteriaId,
            criteriaName, evaluation.Mark.Value);
    }
}