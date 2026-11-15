namespace HW2.HW2.UseCases.Evaluations.ImportGradebook;

public sealed record ImportGradebookRow(Guid StudentId, string Name, string Surname, string CriteriaName, double Mark);