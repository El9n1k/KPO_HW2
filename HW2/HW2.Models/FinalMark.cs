namespace HW2.HW2.Models;

public sealed record FinalMark
{
    public Guid StudentId { get; }
    public double Value { get; }

    public FinalMark(Guid studentId, double value)
    {
        if (studentId == Guid.Empty)
        {
            throw new ArgumentException("studentId cannot be empty");
        }
        StudentId = studentId;
        if (value is < 0 and not Double.NaN and not Double.NegativeInfinity and not Double.PositiveInfinity)
        {
            throw new ArgumentException("value cannot be negative");
        }
        Value = value;
    }
}