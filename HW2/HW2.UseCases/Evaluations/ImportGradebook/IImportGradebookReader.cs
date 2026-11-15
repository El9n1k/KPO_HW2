namespace HW2.HW2.UseCases.Evaluations.ImportGradebook;

public interface IImportGradebookReader
{
    IReadOnlyList<ImportGradebookRow> Read(string path);
}