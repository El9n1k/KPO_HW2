using Xunit;
using HW2.HW2.Models;

namespace HW2.HW2.Tests;

public class EvaluationTests
{
    private static readonly Student Student = new(Guid.NewGuid(), "Иван", "Иванов");

    private static Criteria Exam()
    {
        return new(Guid.NewGuid(), "Экзамен", maxMark: 10, weight: 0.6);
    }

    [Fact]
    public void CreateMarkAboveMaxThrows()
    {
        Assert.Throws<ArgumentException>(() =>
            new Evaluation(Guid.NewGuid(), Student.Id, Exam(), new Mark(12)));
    }

    [Fact]
    public void CreateMarkEqualToMaxIsAllowed()
    {
        Evaluation evaluation = new(Guid.NewGuid(), Student.Id, Exam(), new Mark(10));

        Assert.Equal(10, evaluation.Mark.Value);
    }

    [Fact]
    public void CreateStoresCriteriaId()
    {
        Criteria criteria = Exam();

        Evaluation evaluation = new(Guid.NewGuid(), Student.Id, criteria, new Mark(5));

        Assert.Equal(criteria.Id, evaluation.CriteriaId);
    }

    [Fact]
    public void ChangeMarkAboveMaxThrowsAndKeepsOldMark()
    {
        Criteria criteria = Exam();
        Evaluation evaluation = new(Guid.NewGuid(), Student.Id, criteria, new Mark(7));

        Assert.Throws<ArgumentException>(() => evaluation.ChangeMark(new Mark(11), criteria));

        Assert.Equal(7, evaluation.Mark.Value);
    }

    [Fact]
    public void ChangeMarkWithForeignCriteriaThrows()
    {
        Evaluation evaluation = new(Guid.NewGuid(), Student.Id, Exam(), new Mark(7));

        Assert.Throws<ArgumentException>(() => evaluation.ChangeMark(new Mark(5), Exam()));
    }

}