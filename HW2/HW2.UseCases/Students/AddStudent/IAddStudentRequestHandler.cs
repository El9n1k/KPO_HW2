namespace HW2.HW2.UseCases.Students.AddStudent;

public interface IAddStudentRequestHandler
{
    AddStudentResponse Handle(AddStudentRequest request);
}