using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Evaluations.CalculateFinalEvaluation;

internal sealed class CalculateFinalEvaluationRequestHandler : ICalculateFinalEvaluationRequestHandler
{
    private readonly ICalculateFinalEvaluationRepository _repository;
    private readonly IFinalMarkCalculation _calculation;

    public CalculateFinalEvaluationRequestHandler(ICalculateFinalEvaluationRepository repository, IFinalMarkCalculation calculation)
    {
        _repository = repository;
        _calculation = calculation;
    }

    public CalculateFinalEvaluationResponse Handle(CalculateFinalEvaluationRequest request)
    {
        FinalMark finalMark = _calculation.StudentCalculateFinalMark(request.StudentId, _repository.GetAllCriteria(), _repository.GetEvaluations());
        return new CalculateFinalEvaluationResponse(finalMark.Value);
    }
}