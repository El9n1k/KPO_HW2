namespace HW2.HW2.Models;

public sealed record Mark
{
    public double Value { get; }

    public Mark(double value)
    {
        if (double.IsNaN(value) || double.IsInfinity(value) || value < 0)
        {
            throw new ArgumentException("Mark cannot be negative/Nan/infinity");
        }
        Value = value;
    }
}