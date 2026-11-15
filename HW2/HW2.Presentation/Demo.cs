using HW2.HW2.UseCases.Criterias.AddCriteria;
using HW2.HW2.UseCases.Facade;
using HW2.HW2.UseCases.Evaluations.CalculateFinalEvaluation;
using HW2.HW2.UseCases.Evaluations.SetEvaluation;
using HW2.HW2.UseCases.Students.AddStudent;

namespace HW2.HW2.Presentation;

public sealed class Demo
{
    private const string ExportPath = "exported.json";

    private readonly IUseCaseFacade _facade;

    public Demo(IUseCaseFacade facade)
    {
        _facade = facade;
    }

    public void RunDemo()
    {
        Console.WriteLine("1. Заводим студентов и критерии");
        Guid ivan = AddStudent("Иван", "Иванов");
        Guid anna = AddStudent("Анна", "Петрова");
        Guid exam = AddCriteria("Экзамен", 10, 0.6);
        Guid homework = AddCriteria("Домашки", 10, 0.4);

        Console.WriteLine("\n2. Выставляем оценки");
        SetMark("Иванов - Экзамен", ivan, exam, 8);
        SetMark("Иванов - Домашки", ivan, homework, 10);
        SetMark("Петрова - Экзамен", anna, exam, 10);
        SetMark("Петрова - Домашки", anna, homework, 9);

        Console.WriteLine("\n3. Получаем итог");
        CalculateFinalEvaluationResponse single =
            _facade.CalculateFinalEvaluation(new CalculateFinalEvaluationRequest(ivan));
        Console.WriteLine($"Итог Иванова: {single.Value}");

        CalculateAllFinalsResponse all = _facade.CalculateAllFinals();
        foreach (StudentFinalEvaluation final in all.Finals)
        {
            Console.WriteLine($"{final.Surname} {final.Name}: {final.Value}");
        }

        foreach (string error in all.Errors)
        {
            Console.WriteLine($"Пропущено из-за ошибки: {error}");
        }

        Console.WriteLine("\n4. Экспорт итога");
        CalculateAllFinalsResponse exported = _facade.ExportFinals(ExportPath);
        Console.WriteLine($"Экспортировано итогов: {exported.Finals.Count}, файл: {Path.GetFullPath(ExportPath)}");
    }

    private Guid AddStudent(string name, string surname)
    {
        AddStudentResponse response = _facade.AddStudent(new AddStudentRequest(name, surname));
        Console.WriteLine($"Студент {surname} {name}, id: {response.Id}");
        return response.Id;
    }

    private Guid AddCriteria(string name, double maxMark, double weight)
    {
        AddCriteriaResponse response = _facade.AddCriteria(new AddCriteriaRequest(name, maxMark, weight));
        Console.WriteLine($"Критерий {name}, максимум {maxMark}, вес {weight}, id: {response.Id}");
        return response.Id;
    }

    private void SetMark(string title, Guid studentId, Guid criteriaId, double mark)
    {
        _facade.SetEvaluation(new SetEvaluationRequest(studentId, criteriaId, mark));
        Console.WriteLine($"{title}: {mark}");
    }
}