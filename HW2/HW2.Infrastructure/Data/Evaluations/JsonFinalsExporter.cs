using System.Text.Encodings.Web;
using System.Text.Json;
using HW2.HW2.UseCases.Facade;

namespace HW2.HW2.Infrastructure.Data.Evaluations;

internal sealed class JsonFinalsExporter : IFinalsExporter
{
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping   // иначе кириллица запишется как \u0418
    };

    public void Export(IReadOnlyList<StudentFinalEvaluation> finals, string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException("Путь к файлу не указан");
        }

        try
        {
            File.WriteAllText(path, JsonSerializer.Serialize(finals, Options));
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            throw new ArgumentException($"Не удалось записать файл '{path}': {ex.Message}");
        }
    }
}