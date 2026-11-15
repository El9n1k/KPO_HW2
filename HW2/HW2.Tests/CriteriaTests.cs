using Xunit;
using HW2.HW2.Models;

namespace HW2.HW2.Tests;

public class CriteriaTests
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void CreateBlankNameThrows(string name)
    {
        Assert.Throws<ArgumentException>(() => new Criteria(Guid.NewGuid(), name, 10, 1));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    [InlineData(double.NaN)]
    public void CreateInvalidMaxMarkThrows(double maxMark)
    {
        Assert.Throws<ArgumentException>(() => new Criteria(Guid.NewGuid(), "Экзамен", maxMark, 1));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-0.5)]
    [InlineData(double.NaN)]
    public void CreateInvalidWeightThrows(double weight)
    {
        Assert.Throws<ArgumentException>(() => new Criteria(Guid.NewGuid(), "Экзамен", 10, weight));
    }

    [Fact]
    public void CreateEmptyIdThrows()
    {
        Assert.Throws<ArgumentException>(() => new Criteria(Guid.Empty, "Экзамен", 10, 1));
    }
}