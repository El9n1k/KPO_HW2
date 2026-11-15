using HW2.HW2.Models;

namespace HW2.HW2.UseCases.Criterias.AddCriteria;

internal static class CriteriaMapper
{
    public static Criteria ToEntity(this AddCriteriaRequest request)
    {
        return new Criteria(
            Guid.NewGuid(), request.Name, request.MaxMark, request.Weight);
    }

    public static AddCriteriaResponse ToDto(this Criteria criteria)
    {
        return new AddCriteriaResponse(criteria.Id);
    }
}