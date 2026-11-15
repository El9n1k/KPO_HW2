namespace HW2.HW2.UseCases.Facade;

public interface IFinalsExporter
{
    void Export(IReadOnlyList<StudentFinalEvaluation> finals, string path);
}