using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Criterias.ListCriterias;

public interface IListCriteriasRepository
{
    IReadOnlyList<Criteria> GetAll();
}