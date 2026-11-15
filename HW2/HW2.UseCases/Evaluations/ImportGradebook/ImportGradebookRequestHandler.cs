using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Evaluations.ImportGradebook;

internal sealed class ImportGradebookRequestHandler : IImportGradebookRequestHandler
{
    private readonly IImportGradebookRepository _repository;
    private readonly IImportGradebookReader _reader;
    private readonly EvaluationFactory _factory;

    public ImportGradebookRequestHandler(IImportGradebookRepository repository, IImportGradebookReader reader, EvaluationFactory factory)
    {
        _repository = repository;
        _reader = reader;
        _factory = factory;
    }

    public ImportGradebookResponse Handle(ImportGradebookRequest request)
    {
        IReadOnlyList<ImportGradebookRow> rows = _reader.Read(request.Path);

        int imported = 0;
        List<string> errors = new();
        for (int i = 0; i < rows.Count; i++)
        {
            ImportGradebookRow row = rows[i];
            try
            {
                Student student = _repository.GetStudentById(row.StudentId) ??
                                  throw new ArgumentException($"Student {row.StudentId} " +
                                                              $"not found. Add it first and import again");

                Criteria criteria = _repository.FindCriteriaByName(row.CriteriaName)
                                    ?? throw new ArgumentException(
                                        $"Criteria '{row.CriteriaName}' not found. " +
                                        $"Add it first and import again");

                Mark mark = new(row.Mark);

                Evaluation? evaluation = _repository.Find(row.StudentId, criteria.Id);
                if (evaluation is null)
                {
                    evaluation = _factory.Create(student, criteria, mark);
                }
                else
                {
                    evaluation.ChangeMark(mark, criteria);
                }

                _repository.Save(evaluation);
                imported++;
            }
            catch (Exception ex) when (ex is ArgumentException)
            {
                errors.Add($"Row {i + 1}: {ex.Message}");
            }
        }

        return new ImportGradebookResponse(imported, errors);
    }
}