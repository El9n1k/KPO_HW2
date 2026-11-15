namespace HW2.HW2.UseCases.Criterias.AddCriteria;

public interface IAddCriteriaRequestHandler
{
    AddCriteriaResponse Handle(AddCriteriaRequest request);
}