namespace HW2.HW2.Presentation;

public class ConsoleUI : IConsoleUI
{
    private readonly Dictionary<string, Action> _commands;

    public ConsoleUI(StudentMenu students, CriteriaMenu criterias, EvaluationMenu evaluations, Demo demo)
    {
        _commands = new(StringComparer.OrdinalIgnoreCase)
        {
            ["student add"] = students.Add,
            ["student list"] = students.List,
            ["criteria add"] = criterias.Add,
            ["criteria list"] = criterias.List,
            ["evaluation set"] = evaluations.Set,
            ["evaluation list"] = evaluations.List,
            ["evaluation calculate final"] = evaluations.CalculateFinal,
            ["evaluation delete"] = evaluations.Delete,
            ["evaluation import gradebook"] = evaluations.ImportGradebook,
            ["evaluation calculate all"] = evaluations.CalculateAll,
            ["evaluation export final"] = evaluations.ExportFinals,
            ["demo"] = demo.RunDemo,
            ["help"] = Help
        };
    }

    public static void Help()
    {
        Console.WriteLine("Команды: demo, student add, student list, criteria add, criteria list, evaluation set, " +
                          "evaluation list, evaluation calculate final, evaluation delete, evaluation import " +
                          "gradebook, evaluation calculate all, evaluation export final, exit");
    }

    public void Run()
    {
        Help();

        while (true)
        {
            Console.Write("Введите команду: ");
            string? line = Console.ReadLine();
            if (line is null)
            {
                return;
            }

            string key = string.Join(' ', line.Split(' ', StringSplitOptions.RemoveEmptyEntries));

            if (key.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            if (key.Length == 0)
            {
                continue;
            }

            if (!_commands.TryGetValue(key, out Action? command))
            {
                Console.WriteLine("Неизвестная команда");
                continue;
            }

            try
            {
                command();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}