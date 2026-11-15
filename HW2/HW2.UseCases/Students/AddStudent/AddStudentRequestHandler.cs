using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Students.AddStudent;

internal sealed class AddStudentRequestHandler : IAddStudentRequestHandler
{
    private readonly IAddStudentRepository _repository;

    public AddStudentRequestHandler(IAddStudentRepository repository)
    {
        _repository = repository;
    }

    public AddStudentResponse Handle(AddStudentRequest request)
    {
        Student student = request.ToEntity();

        _repository.Add(student);

        return student.ToDto();
    }
}