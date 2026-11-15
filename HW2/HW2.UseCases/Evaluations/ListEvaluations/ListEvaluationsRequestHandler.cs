using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Evaluations.ListEvaluations;

internal sealed class ListEvaluationsRequestHandler : IListEvaluationsRequestHandler
{
    private readonly IListEvaluationsRepository _repository;

    public ListEvaluationsRequestHandler(IListEvaluationsRepository repository)
    {
        _repository = repository;
    }

    public ListEvaluationsResponse Handle()
    {
        IReadOnlyList<Evaluation> evaluations = _repository.GetAllEvaluations();
        IReadOnlyDictionary<Guid, Student> students = _repository.GetAllStudents();
        IReadOnlyDictionary<Guid, Criteria> criterias = _repository.GetAllCriterias();

        List<ListEvaluationsResponseItem> response = new(evaluations.Count);
        foreach (Evaluation evaluation in evaluations)
        {
            Student student = students[evaluation.StudentId];
            response.Add(evaluation.ToDto(student.Name, student.Surname, 
                criterias[evaluation.CriteriaId].Name));
        }

        return new ListEvaluationsResponse(response);
    }
}