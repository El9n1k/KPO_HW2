using Xunit;
using HW2.HW2.Models;
namespace HW2.HW2.Tests;


public class MarkTests
{
    [Fact]
    public void CreateNegativeThrows()
    {
        Assert.Throws<ArgumentException>(() => new Mark(-1));
    }

    [Fact]
    public void CreateZeroIsAllowed()
    {
        Assert.Equal(0, new Mark(0).Value);
    }

    [Theory]
    [InlineData(double.NaN)]
    [InlineData(double.PositiveInfinity)]
    public void CreateNotFiniteThrows(double value)
    {
        Assert.Throws<ArgumentException>(() => new Mark(value));
    }
}