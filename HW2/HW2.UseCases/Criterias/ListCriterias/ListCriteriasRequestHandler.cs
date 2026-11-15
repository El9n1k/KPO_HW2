using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Criterias.ListCriterias;

internal sealed class ListCriteriasRequestHandler : IListCriteriasRequestHandler
{
    private readonly IListCriteriasRepository _repository;

    public ListCriteriasRequestHandler(IListCriteriasRepository repository)
    {
        _repository = repository;
    }

    public ListCriteriasResponse Handle()
    {
        IReadOnlyList<Criteria> criterias = _repository.GetAll();

        return new ListCriteriasResponse(criterias.Select(CriteriaMapper.ToDto).ToList());
    }
}