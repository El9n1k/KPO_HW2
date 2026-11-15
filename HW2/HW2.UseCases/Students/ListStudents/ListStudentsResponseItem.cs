namespace HW2.HW2.UseCases.Students.ListStudents;

public sealed record ListStudentsResponseItem(
    Guid Id, string Name, string Surname);