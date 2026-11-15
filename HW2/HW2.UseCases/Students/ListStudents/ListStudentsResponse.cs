namespace HW2.HW2.UseCases.Students.ListStudents;

public sealed record ListStudentsResponse(
    IReadOnlyList<ListStudentsResponseItem> Students);