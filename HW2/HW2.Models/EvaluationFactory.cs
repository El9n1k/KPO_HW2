namespace HW2.HW2.Models;

public sealed class EvaluationFactory
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static",
        Justification = "Фабрика внедряется через DI и может получить зависимости")]
    public Evaluation Create(Student student, Criteria criteria, Mark mark)
    {
        if (student is null)
        {
            throw new ArgumentException("Student cannot be null");
        }

        if (criteria is null)
        {
            throw new ArgumentException("Criteria cannot be null");
        }

        if (mark is null)
        {
            throw new ArgumentException("Mark cannot be null");
        }

        return new Evaluation(Guid.NewGuid(), student.Id, criteria, mark);
    }
}