namespace HW2.HW2.UseCases.Criterias.ListCriterias;

public sealed record ListCriteriasResponse(
    IReadOnlyList<ListCriteriasResponseItem> Items);