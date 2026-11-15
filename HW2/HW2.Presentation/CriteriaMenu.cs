using System.Globalization;

using HW2.HW2.UseCases.Criterias.AddCriteria;
using HW2.HW2.UseCases.Criterias.ListCriterias;
using HW2.HW2.UseCases.Facade;

namespace HW2.HW2.Presentation;

public sealed class CriteriaMenu
{
    private readonly IUseCaseFacade _facade;

    public CriteriaMenu(IUseCaseFacade facade)
    {
        _facade = facade;
    }

    public void Add()
    {
        Console.Write("Название критерия: ");
        string name = Console.ReadLine() ?? string.Empty;

        Console.Write("Максимальная оценка: ");
        string? mark = Console.ReadLine()?.Replace(',', '.');
        if (!double.TryParse(mark, NumberStyles.Any, CultureInfo.InvariantCulture, out double markValue))
        {
            throw new ArgumentException("Mark must be a positive number");
        }

        Console.Write("Вес: ");
        string? weight = Console.ReadLine()?.Replace(',', '.');
        if (!double.TryParse(weight, NumberStyles.Any, CultureInfo.InvariantCulture, out double weightValue))
        {
            throw new ArgumentException("Weight must be a positive number");
        }

        AddCriteriaResponse response = _facade.AddCriteria(new AddCriteriaRequest(name, markValue, weightValue));
        Console.WriteLine($"Критерий добавлен, id: {response.Id}");
    }

    public void List()
    {
        ListCriteriasResponse response = _facade.ListCriterias();

        if (response.Items.Count == 0)
        {
            Console.WriteLine("Критериев нет");
            return;
        }

        foreach (ListCriteriasResponseItem criteria in response.Items)
        {
            Console.WriteLine($"{criteria.Id}: {criteria.name}, максимальная оценка - {criteria.MaxMark}, " +
                              $"вес - {criteria.Weight}");
        }
    }
}