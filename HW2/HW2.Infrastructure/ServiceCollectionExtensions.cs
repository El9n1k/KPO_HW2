using Microsoft.Extensions.DependencyInjection;
using HW2.HW2.Infrastructure.Data;
using HW2.HW2.Infrastructure.Data.Criterias;
using HW2.HW2.Infrastructure.Data.Evaluations;
using HW2.HW2.Infrastructure.Data.Students;
using HW2.HW2.UseCases.Criterias.AddCriteria;
using HW2.HW2.UseCases.Criterias.ListCriterias;
using HW2.HW2.UseCases.Evaluations.CalculateFinalEvaluation;
using HW2.HW2.UseCases.Evaluations.DeleteEvaluation;
using HW2.HW2.UseCases.Evaluations.ImportGradebook;
using HW2.HW2.UseCases.Evaluations.ListEvaluations;
using HW2.HW2.UseCases.Evaluations.SetEvaluation;
using HW2.HW2.UseCases.Students.AddStudent;
using HW2.HW2.UseCases.Students.ListStudents;
using HW2.HW2.UseCases.Facade;

namespace HW2.HW2.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string path)
    {
        services.AddSingleton<IDataStorage>(_ => new JsonStorage(path));
        services.AddSingleton<IListCriteriasRepository, ListCriteriasRepository>();
        services.AddSingleton<IAddCriteriaRepository, AddCriteriaRepository>();
        services.AddSingleton<IListStudentsRepository, ListStudentsRepository>();
        services.AddSingleton<IAddStudentRepository, AddStudentRepository>();
        services.AddSingleton<IListEvaluationsRepository, ListEvaluationsRepository>();
        services.AddSingleton<ISetEvaluationRepository, SetEvaluationRepository>();
        services.AddSingleton<IImportGradebookReader, ImportGradebookReader>();
        services.AddSingleton<IImportGradebookRepository, ImportGradebookRepository>();
        services.AddSingleton<IDeleteEvaluationRepository, DeleteEvaluationRepository>();
        services.AddSingleton<ICalculateFinalEvaluationRepository, CalculateFinalEvaluationRepository>();
        services.AddSingleton<IFinalsExporter, JsonFinalsExporter>();

        return services;
    }
}