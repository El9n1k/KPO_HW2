using HW2.HW2.UseCases.Criterias.AddCriteria;
using HW2.HW2.UseCases.Criterias.ListCriterias;
using HW2.HW2.UseCases.Evaluations.CalculateFinalEvaluation;
using HW2.HW2.UseCases.Evaluations.DeleteEvaluation;
using HW2.HW2.UseCases.Evaluations.ImportGradebook;
using HW2.HW2.UseCases.Evaluations.ListEvaluations;
using HW2.HW2.UseCases.Evaluations.SetEvaluation;
using HW2.HW2.UseCases.Students.AddStudent;
using HW2.HW2.UseCases.Students.ListStudents;

namespace HW2.HW2.UseCases.Facade;

internal sealed class UseCaseFacade : IUseCaseFacade
{
    private readonly IAddStudentRequestHandler _addStudent;
    private readonly IListStudentsRequestHandler _listStudents;
    private readonly IAddCriteriaRequestHandler _addCriteria;
    private readonly IListCriteriasRequestHandler _listCriterias;
    private readonly ICalculateFinalEvaluationRequestHandler _calculateFinal;
    private readonly IDeleteEvaluationRequestHandler _deleteEvaluation;
    private readonly IImportGradebookRequestHandler _importGradebook;
    private readonly IListEvaluationsRequestHandler _listEvaluations;
    private readonly ISetEvaluationRequestHandler _setEvaluation;
    private readonly IFinalsExporter _exporter;

    public UseCaseFacade(
        IAddStudentRequestHandler addStudent,
        IListStudentsRequestHandler listStudents,
        IAddCriteriaRequestHandler addCriteria,
        IListCriteriasRequestHandler listCriterias,
        ISetEvaluationRequestHandler setEvaluation,
        IListEvaluationsRequestHandler listEvaluations,
        IDeleteEvaluationRequestHandler deleteEvaluation,
        ICalculateFinalEvaluationRequestHandler calculateFinal,
        IImportGradebookRequestHandler importGradebook,
        IFinalsExporter exporter)
    {
        _addStudent = addStudent;
        _listStudents = listStudents;
        _addCriteria = addCriteria;
        _listCriterias = listCriterias;
        _setEvaluation = setEvaluation;
        _listEvaluations = listEvaluations;
        _deleteEvaluation = deleteEvaluation;
        _calculateFinal = calculateFinal;
        _importGradebook = importGradebook;
        _exporter = exporter;
    }

    public AddStudentResponse AddStudent(AddStudentRequest request)
    {
        return _addStudent.Handle(request);
    }

    public ListStudentsResponse ListStudents()
    {
        return _listStudents.Handle();
    }

    public AddCriteriaResponse AddCriteria(AddCriteriaRequest request)
    {
        return _addCriteria.Handle(request);
    }

    public ListCriteriasResponse ListCriterias()
    {
        return _listCriterias.Handle();
    }

    public SetEvaluationResponse SetEvaluation(SetEvaluationRequest request)
    {
        return _setEvaluation.Handle(request);
    }

    public ListEvaluationsResponse ListEvaluations()
    {
        return _listEvaluations.Handle();
    }

    public ImportGradebookResponse ImportGradebook(ImportGradebookRequest request)
    {
        return _importGradebook.Handle(request);
    }

    public void DeleteEvaluation(DeleteEvaluationRequest request)
    {
        _deleteEvaluation.Handle(request);
    }

    public CalculateFinalEvaluationResponse CalculateFinalEvaluation(CalculateFinalEvaluationRequest request)
    {
        return _calculateFinal.Handle(request);
    }

    public CalculateAllFinalsResponse CalculateAllFinals()
    {
        List<StudentFinalEvaluation> finals = new();
        List<string> errors = new();

        foreach (ListStudentsResponseItem student in _listStudents.Handle().Students)
        {
            try
            {
                CalculateFinalEvaluationResponse response =
                    _calculateFinal.Handle(new CalculateFinalEvaluationRequest(student.Id));

                finals.Add(new StudentFinalEvaluation(student.Id, student.Name, student.Surname, response.Value));
            }
            catch (ArgumentException ex)
            {
                errors.Add($"{student.Surname} {student.Name}: {ex.Message}");
            }
        }

        return new CalculateAllFinalsResponse(finals, errors);
    }

    public CalculateAllFinalsResponse ExportFinals(string path)
    {
        CalculateAllFinalsResponse response = CalculateAllFinals();
        
        if (response.Finals.Count == 0)
        {
            throw new ArgumentException("Нет итогов для экспорта");
        }

        _exporter.Export(response.Finals, path);
        return response;
    }
}
