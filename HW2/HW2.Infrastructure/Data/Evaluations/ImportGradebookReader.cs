using HW2.HW2.UseCases.Evaluations.ImportGradebook;
using System.Text.Json;
using HW2.HW2.Infrastructure.Data.Dtos;

namespace HW2.HW2.Infrastructure.Data.Evaluations;

internal sealed class ImportGradebookReader : IImportGradebookReader
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public IReadOnlyList<ImportGradebookRow> Read(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException("Путь к файлу не указан");
        }

        if (!File.Exists(path))
        {
            throw new ArgumentException($"Файл '{path}' не найден");
        }

        string json = File.ReadAllText(path);
        try
        {
            json = File.ReadAllText(path);
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Не удалось прочитать файл '{path}': {ex.Message}");
        }
        
        if (!json.TrimStart().StartsWith('['))
        {
            throw new ArgumentException(
                $"Файл '{path}' не похож на ведомость: ожидается JSON-массив строк " +
                "(StudentId, Name, Surname, CriteriaName, Mark)");
        }

        List<ImportGradebookRow?>? rows;
        try
        {
            rows = JsonSerializer.Deserialize<List<ImportGradebookRow?>>(json, Options);
        }
        catch (JsonException ex)
        {
            throw new ArgumentException($"Файл '{path}' содержит некорректный JSON: {ex.Message}");
        }

        if (rows is null)
        {
            throw new ArgumentException($"Файл '{path}' не содержит данных");
        }

        List<ImportGradebookRow> result = new(rows.Count);
        for (int i = 0; i < rows.Count; i++)
        {
            ImportGradebookRow? row = rows[i];

            if (row is null)
            {
                throw new ArgumentException($"Запись {i + 1}: пустой элемент");
            }

            if (row.StudentId == Guid.Empty)
            {
                throw new ArgumentException($"Запись {i + 1}: не указан StudentId");
            }

            if (string.IsNullOrWhiteSpace(row.CriteriaName))
            {
                throw new ArgumentException($"Запись {i + 1}: не указан CriteriaName");
            }

            result.Add(row);
        }

        return result;
    }
}