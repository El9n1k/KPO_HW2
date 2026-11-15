using Xunit;
using HW2.HW2.Models;

namespace HW2.HW2.Tests;

public class FinalMarkCalculationTests
{
    private readonly FinalMarkCalculation calculation = new(new FinalMarkCalculationStrategy());

    private static readonly Criteria Exam = new(Guid.NewGuid(), "Экзамен", 10, 0.6);
    private static readonly Criteria Homework = new(Guid.NewGuid(), "Домашки", 10, 0.4);

    private static Evaluation Mark(Guid studentId, Criteria criteria, double value)
    {
        return new(Guid.NewGuid(), studentId, criteria, new HW2.Models.Mark(value));
    }

    [Fact]
    public void CalculateIsWeightedSum()
    {
        Guid student = Guid.NewGuid();
        Evaluation[] evaluations = [Mark(student, Exam, 8), Mark(student, Homework, 10)];

        FinalMark result = calculation.StudentCalculateFinalMark(student, [Exam, Homework], evaluations);

        Assert.Equal(8.8, result.Value, precision: 10);
    }

    [Fact]
    public void CalculateIgnoresOtherStudentsEvaluations()
    {
        Guid student = Guid.NewGuid();
        Evaluation[] evaluations =
        [
            Mark(student, Exam, 8),
            Mark(Guid.NewGuid(), Exam, 10)
        ];

        FinalMark result = calculation.StudentCalculateFinalMark(student, [Exam, Homework], evaluations);

        Assert.Equal(4.8, result.Value, precision: 10);
    }

    [Fact]
    public void CalculateStudentWithoutEvaluationsThrows()
    {
        Evaluation[] evaluations = [Mark(Guid.NewGuid(), Exam, 8)];

        Assert.Throws<ArgumentException>(() =>
            calculation.StudentCalculateFinalMark(Guid.NewGuid(), [Exam, Homework], evaluations));
    }

    [Fact]
    public void CalculateEmptyStudentIdThrows()
    {
        Evaluation[] evaluations = [Mark(Guid.NewGuid(), Exam, 8)];

        Assert.Throws<ArgumentException>(() =>
            calculation.StudentCalculateFinalMark(Guid.Empty, [Exam], evaluations));
    }
}