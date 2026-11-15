using HW2.HW2.UseCases.Criterias.AddCriteria;
using HW2.HW2.UseCases.Criterias.ListCriterias;
using HW2.HW2.UseCases.Evaluations.CalculateFinalEvaluation;
using HW2.HW2.UseCases.Evaluations.DeleteEvaluation;
using HW2.HW2.UseCases.Evaluations.ImportGradebook;
using HW2.HW2.UseCases.Evaluations.ListEvaluations;
using HW2.HW2.UseCases.Evaluations.SetEvaluation;
using HW2.HW2.UseCases.Facade;
using HW2.HW2.UseCases.Students.AddStudent;
using HW2.HW2.UseCases.Students.ListStudents;

using Microsoft.Extensions.DependencyInjection;

namespace HW2.HW2.UseCases;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddSingleton<IAddCriteriaRequestHandler, AddCriteriaRequestHandler>();
        services.AddSingleton<IListCriteriasRequestHandler, ListCriteriasRequestHandler>();
        services.AddSingleton<IAddStudentRequestHandler, AddStudentRequestHandler>();
        services.AddSingleton<IListStudentsRequestHandler, ListStudentsRequestHandler>();
        services.AddSingleton<ISetEvaluationRequestHandler, SetEvaluationRequestHandler>();
        services.AddSingleton<IListEvaluationsRequestHandler, ListEvaluationsRequestHandler>();
        services.AddSingleton<IImportGradebookRequestHandler, ImportGradebookRequestHandler>();
        services.AddSingleton<IDeleteEvaluationRequestHandler, DeleteEvaluationRequestHandler>();
        services.AddSingleton<ICalculateFinalEvaluationRequestHandler, CalculateFinalEvaluationRequestHandler>();
        services.AddSingleton<IUseCaseFacade, UseCaseFacade>();

        return services;
    }
}