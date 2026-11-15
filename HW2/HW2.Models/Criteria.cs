namespace HW2.HW2.Models;

public sealed class Criteria
{
    public Guid Id { get; }
    public string Name {get;}
    public double MaxMark { get; }
    public double Weight { get; }

    public Criteria(Guid id, string name, double maxMark, double weight)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id cannot be empty");
        }
        Id = id;
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Criteria name cannot be empty", nameof(name));
        }
        Name = name;
        if (double.IsNaN(maxMark) || double.IsPositiveInfinity(maxMark) || maxMark <= 0)
        {
            throw new ArgumentException("Max mark must be greater than zero", nameof(maxMark));
        }
        MaxMark = maxMark;
        if (double.IsNaN(weight) || double.IsPositiveInfinity(weight) || weight <= 0)
        {
            throw new ArgumentException("Weight must be greater than zero", nameof(weight));
        }
        Weight = weight;
    }

    public void EnsureScoreAllowed(Mark mark)
    {
        if (mark.Value > MaxMark)
        {
            throw new ArgumentException($"Mark {mark.Value} cannot be greater than max mark {MaxMark} by criteria {Name}");   
        }
    }
}