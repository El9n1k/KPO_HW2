namespace HW2.HW2.UseCases.Evaluations.CalculateFinalEvaluation;

public interface ICalculateFinalEvaluationRequestHandler
{
    CalculateFinalEvaluationResponse Handle(CalculateFinalEvaluationRequest request);
}