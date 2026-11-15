using Microsoft.Extensions.DependencyInjection;

namespace HW2.HW2.Presentation;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddSingleton<StudentMenu>();
        services.AddSingleton<CriteriaMenu>();
        services.AddSingleton<EvaluationMenu>();
        services.AddSingleton<Demo>();
        services.AddSingleton<IConsoleUI, ConsoleUI>();

        return services;
    }
}