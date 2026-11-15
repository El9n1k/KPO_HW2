using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Students.AddStudent;

public interface IAddStudentRepository
{
    void Add(Student student);
}