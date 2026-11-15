using Xunit;
using HW2.HW2.Models;

namespace HW2.HW2.Tests;

public class StudentTests
{
    [Theory]
    [InlineData("", "Иванов")]
    [InlineData("Иван", " ")]
    public void CreateBlankNameOrSurnameThrows(string name, string surname)
    {
        Assert.Throws<ArgumentException>(() => new Student(Guid.NewGuid(), name, surname));
    }
}