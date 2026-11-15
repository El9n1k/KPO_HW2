using HW2.HW2.Models;
using HW2.HW2.UseCases.Criterias.ListCriterias;

namespace HW2.HW2.Infrastructure.Data.Criterias;

internal sealed class ListCriteriasRepository(IDataStorage storage) : IListCriteriasRepository
{
    public IReadOnlyList<Criteria> GetAll()
    {
        return storage.Load().Criterias.Values.Select(DataMapper.ToDomain).ToList();
    }
}