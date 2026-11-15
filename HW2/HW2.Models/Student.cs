namespace HW2.HW2.Models;

public sealed class Student
{
    public Guid Id { get; }
    public string Name { get; }
    public string Surname { get; }

    public Student(Guid id, string name, string surname)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id cannot be empty");
        }

        Id = id;
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty", nameof(name));
        }
        Name = name;
        if (string.IsNullOrWhiteSpace(surname))
        {
            throw new ArgumentException("Surname cannot be empty", nameof(surname));
        }
        Surname = surname;
    }
}