using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Students.AddStudent;

internal static class StudentMapper
{
    public static Student ToEntity(this AddStudentRequest request)
    {
        return new Student(
        Guid.NewGuid(), request.Name, request.Surname);
    }

    public static AddStudentResponse ToDto(this Student student)
    {
        return new AddStudentResponse(student.Id);
    }
}