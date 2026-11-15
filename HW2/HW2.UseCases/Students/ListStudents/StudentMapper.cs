using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Students.ListStudents;

internal static class StudentMapper
{
    public static ListStudentsResponseItem ToDto(this Student student)
    {
        return new ListStudentsResponseItem(student.Id, student.Name, student.Surname);
    }
}