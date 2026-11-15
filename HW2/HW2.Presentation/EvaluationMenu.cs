using System.Globalization;

using HW2.HW2.UseCases.Evaluations.CalculateFinalEvaluation;
using HW2.HW2.UseCases.Evaluations.DeleteEvaluation;
using HW2.HW2.UseCases.Evaluations.ImportGradebook;
using HW2.HW2.UseCases.Evaluations.ListEvaluations;
using HW2.HW2.UseCases.Evaluations.SetEvaluation;
using HW2.HW2.UseCases.Facade;

namespace HW2.HW2.Presentation;

public sealed class EvaluationMenu
{
    private readonly IUseCaseFacade _facade;

    public EvaluationMenu(IUseCaseFacade facade)
    {
        _facade = facade;
    }

    public void Set()
    {
        Console.Write("Id студента: ");
        string? student = Console.ReadLine()?.Replace(',', '.');
        if (!Guid.TryParse(student, out Guid studentId))
        {
            throw new ArgumentException("Id must be a positive number");
        }

        Console.Write("Id критерия: ");
        string? criteria = Console.ReadLine()?.Replace(',', '.');
        if (!Guid.TryParse(criteria, out Guid criteriaId))
        {
            throw new ArgumentException("Id must be a positive number");
        }

        Console.Write("Оценка: ");
        string? value = Console.ReadLine()?.Replace(',', '.');
        if (!double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double mark))
        {
            throw new ArgumentException("Value must be a positive number");
        }

        SetEvaluationResponse response = _facade.SetEvaluation(new SetEvaluationRequest(studentId, criteriaId, mark));
        Console.WriteLine($"Оценка добавлена, id оценки: {response.EvaluationId}");
    }

    public void List()
    {
        ListEvaluationsResponse response = _facade.ListEvaluations();

        if (response.Evaluations.Count == 0)
        {
            Console.WriteLine("Оценок нет");
            return;
        }

        foreach (ListEvaluationsResponseItem mark in response.Evaluations)
        {
            Console.WriteLine($"Id оценки {mark.EvaluationId}, {mark.Name} {mark.Surname}, " +
                              $"Критерий {mark.CriteriaName}, оценка: {mark.Mark} ");
        }
    }

    public void CalculateFinal()
    {
        Console.Write("Id студента: ");
        string? student = Console.ReadLine()?.Replace(',', '.');
        if (!Guid.TryParse(student, out Guid studentId))
        {
            throw new ArgumentException("Id must be a positive number");
        }

        CalculateFinalEvaluationResponse response =
            _facade.CalculateFinalEvaluation(new CalculateFinalEvaluationRequest(studentId));

        Console.WriteLine($"Оценка: {response.Value}, Id студента {studentId}");
    }

    public void CalculateAll()
    {
        CalculateAllFinalsResponse response = _facade.CalculateAllFinals();
        foreach (StudentFinalEvaluation mark in response.Finals)
        {
            Console.WriteLine($"Студент {mark.Name} {mark.Surname} с ID {mark.StudentId} - оценка {mark.Value}");
        }

        if (response.Errors.Count == 0)
        {
            return;
        }

        Console.WriteLine("Возникла(и) ошибка(и)");
        foreach (string error in response.Errors)
        {
            Console.WriteLine(error);
        }
    }

    public void Delete()
    {
        Console.Write("Id оценки: ");
        string? student = Console.ReadLine()?.Replace(',', '.');
        if (!Guid.TryParse(student, out Guid markId))
        {
            throw new ArgumentException("Id must be a positive number");
        }

        DeleteEvaluationRequest request = new(markId);
        _facade.DeleteEvaluation(request);
        Console.WriteLine("Оценка удалена");
    }

    public void ImportGradebook()
    {
        Console.Write("Путь до базы: ");
        string name = Console.ReadLine() ?? string.Empty;

        ImportGradebookResponse response = _facade.ImportGradebook(new ImportGradebookRequest(name));
        Console.WriteLine($"Всего оценок выставлено: {response.Imported}");
        foreach (string error in response.Errors)
        {
            Console.WriteLine(error);
        }
    }
    
    public void ExportFinals()
    {
        Console.Write("Путь для экспорта: ");
        string path = Console.ReadLine() ?? string.Empty;

        CalculateAllFinalsResponse response = _facade.ExportFinals(path);
        Console.WriteLine($"Экспортировано итогов: {response.Finals.Count}");

        foreach (string error in response.Errors)
        {
            Console.WriteLine($"Пропущено: {error}");
        }
    }
}