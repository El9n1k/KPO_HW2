namespace HW2.HW2.Models;

public interface IFinalMarkCalculationStrategy
{
    public double CalculateFinalMark(IReadOnlyCollection<Criteria> criterias,
        IReadOnlyCollection<Evaluation> evaluations);
}