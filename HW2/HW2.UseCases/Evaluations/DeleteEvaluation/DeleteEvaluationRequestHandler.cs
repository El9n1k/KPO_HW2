namespace HW2.HW2.UseCases.Evaluations.DeleteEvaluation;

internal sealed class DeleteEvaluationRequestHandler : IDeleteEvaluationRequestHandler
{
    private readonly IDeleteEvaluationRepository _repository;

    public DeleteEvaluationRequestHandler(IDeleteEvaluationRepository repository)
    {
        _repository = repository;
    }

    public void Handle(DeleteEvaluationRequest request)
    {
        if (_repository.GetByEvaluationId(request.EvaluationId) is null)
        {
            // throw new ArgumentException($"Evaluation with id {request.EvaluationId} does not exist");
            return;
        }

        _repository.DeleteByEvaluationId(request.EvaluationId);
    }
}