namespace HW2.HW2.Models;

public class FinalMarkCalculation : IFinalMarkCalculation
{
    public IFinalMarkCalculationStrategy Strategy {get; private set; }
    public FinalMarkCalculation(IFinalMarkCalculationStrategy strategy)
    {
        Strategy = strategy ?? throw new ArgumentException("Strategy cannot be null", nameof(strategy));
    }
    public FinalMark StudentCalculateFinalMark(Guid studentId, IReadOnlyCollection<Criteria> criterias,
        IReadOnlyCollection<Evaluation> evaluations)
    {
        if (studentId == Guid.Empty)
        {
            throw new ArgumentException("Student must have ID");
        }

        if (evaluations == null || evaluations.Count == 0)
        {
            throw new ArgumentException("There are no Evaluations");
        }

        bool flag = false;
        foreach (Evaluation evaluation in evaluations)
        {
            if (evaluation.StudentId == studentId)
            {
                flag = true;
                break;
            }
        }

        if (!flag)
        {
            throw new ArgumentException($"There are no evaluations for student with ID {studentId}");
        }
        if (criterias == null || criterias.Count == 0)
        {
            throw new ArgumentException("There are no criterias");
        }

        List<Evaluation> studentsMarks = evaluations
            .Where(e => e.StudentId == studentId)
            .ToList();

        return new FinalMark(studentId, Strategy.CalculateFinalMark(criterias, studentsMarks));
    }

    public void SetStrategy(IFinalMarkCalculationStrategy strategy)
    {
        Strategy = strategy ?? throw new ArgumentException("There are no strategies to calculate final mark");
    }
}