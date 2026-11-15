using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Students.ListStudents;

internal sealed class ListStudentsRequestHandler : IListStudentsRequestHandler
{
    private readonly IListStudentsRepository _repository;

    public ListStudentsRequestHandler(IListStudentsRepository repository)
    {
        _repository = repository;
    }

    public ListStudentsResponse Handle()
    {
        IReadOnlyList<Student> customers = _repository.GetAll();

        return new ListStudentsResponse(customers.Select(StudentMapper.ToDto).ToList());
    }
}