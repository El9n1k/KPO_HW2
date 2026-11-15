using HW2.HW2.Infrastructure.Data.Dtos;
using HW2.HW2.Models;
using HW2.HW2.UseCases.Criterias.AddCriteria;

namespace HW2.HW2.Infrastructure.Data.Criterias;

internal sealed class AddCriteriaRepository(IDataStorage storage) : IAddCriteriaRepository
{
    public void Add(Criteria criteria)
    {
        StorageDto database = storage.Load();
        database.Criterias[criteria.Id] = criteria.ToDto();
        storage.Save(database);
    }
}