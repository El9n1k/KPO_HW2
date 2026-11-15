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

public interface IUseCaseFacade
{
    AddStudentResponse AddStudent(AddStudentRequest request);
    ListStudentsResponse ListStudents();
    AddCriteriaResponse AddCriteria(AddCriteriaRequest request);
    ListCriteriasResponse ListCriterias();
    SetEvaluationResponse SetEvaluation(SetEvaluationRequest request);
    ListEvaluationsResponse ListEvaluations();
    ImportGradebookResponse ImportGradebook(ImportGradebookRequest request);
    void DeleteEvaluation(DeleteEvaluationRequest request);
    CalculateFinalEvaluationResponse CalculateFinalEvaluation(CalculateFinalEvaluationRequest request);
    CalculateAllFinalsResponse CalculateAllFinals();
    CalculateAllFinalsResponse ExportFinals(string path);
}