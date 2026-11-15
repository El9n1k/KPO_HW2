namespace HW2.HW2.UseCases.Evaluations.ImportGradebook;

public sealed record ImportGradebookResponse(int Imported, IReadOnlyList<string> Errors);