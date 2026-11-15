using HW2.HW2.UseCases.Facade;
using HW2.HW2.UseCases.Students.AddStudent;
using HW2.HW2.UseCases.Students.ListStudents;

namespace HW2.HW2.Presentation;

public sealed class StudentMenu
{
    private readonly IUseCaseFacade _facade;

    public StudentMenu(IUseCaseFacade facade)
    {
        _facade = facade;
    }

    public void Add()
    {
        Console.Write("Имя: ");
        string name = Console.ReadLine() ?? string.Empty;

        Console.Write("Фамилия: ");
        string surname = Console.ReadLine() ?? string.Empty;

        AddStudentResponse response = _facade.AddStudent(new AddStudentRequest(name, surname));
        Console.WriteLine($"Студент добавлен, id: {response.Id}");
    }

    public void List()
    {
        ListStudentsResponse response = _facade.ListStudents();

        if (response.Students.Count == 0)
        {
            Console.WriteLine("Студентов нет");
            return;
        }

        foreach (ListStudentsResponseItem student in response.Students)
        {
            Console.WriteLine($"{student.Id}: {student.Surname} {student.Name}");
        }
    }
}