namespace HW2.HW2.UseCases.Evaluations.ImportGradebook;

public interface IImportGradebookRequestHandler
{
    ImportGradebookResponse Handle(ImportGradebookRequest request);
}