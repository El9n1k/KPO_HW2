using HW2.HW2.Infrastructure;
using HW2.HW2.Models;
using HW2.HW2.Presentation;
using HW2.HW2.UseCases;

using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new();
services.AddSingleton<EvaluationFactory>();
services.AddSingleton<IFinalMarkCalculationStrategy, FinalMarkCalculationStrategy>();
services.AddSingleton<IFinalMarkCalculation, FinalMarkCalculation>();

services.AddUseCases().AddInfrastructure("data.json").AddPresentation();

var provider = services.BuildServiceProvider();
provider.GetRequiredService<IConsoleUI>().Run();







