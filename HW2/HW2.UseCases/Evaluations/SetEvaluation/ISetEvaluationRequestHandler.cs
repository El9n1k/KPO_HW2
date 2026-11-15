namespace HW2.HW2.UseCases.Evaluations.SetEvaluation;

public interface ISetEvaluationRequestHandler
{
    SetEvaluationResponse Handle(SetEvaluationRequest request);
}