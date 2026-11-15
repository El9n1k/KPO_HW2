using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Evaluations.SetEvaluation;

internal sealed class SetEvaluationRequestHandler : ISetEvaluationRequestHandler
{
    private readonly ISetEvaluationRepository _repository;
    private readonly EvaluationFactory _factory;

    public SetEvaluationRequestHandler(ISetEvaluationRepository repository, EvaluationFactory factory)
    {
        _repository = repository;
        _factory = factory;
    }

    public SetEvaluationResponse Handle(SetEvaluationRequest request)
    {
        Student student = _repository.GetStudentById(request.StudentId)
                          ?? throw new ArgumentException($"Student with id {request.StudentId} not found");
        Criteria criteria = _repository.GetCriteriaById(request.CriteriaId)
                            ?? throw new ArgumentException($"Criteria with id {request.CriteriaId} not found");

        Mark mark = new(request.Mark);
        Evaluation? evaluation = _repository.Find(request.StudentId, request.CriteriaId);

        if (evaluation is null)
        {
            evaluation = _factory.Create(student, criteria, mark);
        }
        else
        {
            evaluation.ChangeMark(mark, criteria);
        }

        _repository.Save(evaluation);

        return new SetEvaluationResponse(evaluation.Id);
    }
}