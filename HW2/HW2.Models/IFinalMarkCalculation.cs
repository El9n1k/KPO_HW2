namespace HW2.HW2.Models;

public interface IFinalMarkCalculation
{
    IFinalMarkCalculationStrategy Strategy {get;}

    FinalMark StudentCalculateFinalMark(Guid studentId, IReadOnlyCollection<Criteria> criterias,
        IReadOnlyCollection<Evaluation> evaluations);

    void SetStrategy(IFinalMarkCalculationStrategy strategy);
}