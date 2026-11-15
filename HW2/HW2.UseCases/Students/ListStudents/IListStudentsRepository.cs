using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Students.ListStudents;

public interface IListStudentsRepository
{
    IReadOnlyList<Student> GetAll();
}