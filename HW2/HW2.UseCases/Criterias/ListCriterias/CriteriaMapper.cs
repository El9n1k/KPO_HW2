using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Criterias.ListCriterias;

internal static class CriteriaMapper
{
    public static ListCriteriasResponseItem ToDto(this Criteria criteria)
    {
        return new ListCriteriasResponseItem(criteria.Id, criteria.Name, criteria.MaxMark, criteria.Weight);
    }
}