using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Criterias.AddCriteria;

internal sealed class AddCriteriaRequestHandler : IAddCriteriaRequestHandler
{
    private readonly IAddCriteriaRepository _repository;

    public AddCriteriaRequestHandler(IAddCriteriaRepository repository)
    {
        _repository = repository;
    }

    public AddCriteriaResponse Handle(AddCriteriaRequest request)
    {
        Criteria criteria = request.ToEntity();

        _repository.Add(criteria);

        return criteria.ToDto();
    }
}