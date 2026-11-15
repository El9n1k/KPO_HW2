namespace HW2.HW2.Models;

public class FinalMarkCalculationStrategy : IFinalMarkCalculationStrategy
{
    public double CalculateFinalMark(IReadOnlyCollection<Criteria> criterias, IReadOnlyCollection<Evaluation> evaluations)
    {
        Dictionary<Guid, Criteria> criteriasMap = new Dictionary<Guid, Criteria>();
        foreach (Criteria criteria in criterias)
        {
            criteriasMap[criteria.Id] = criteria;
        }
        double result = 0;
        foreach (Evaluation evaluation in evaluations)
        {
            result += criteriasMap[evaluation.CriteriaId].Weight * evaluation.Mark.Value;
        }
        return result;
    }
}