namespace HW2.HW2.UseCases.Criterias.ListCriterias;

public sealed record ListCriteriasResponseItem(
    Guid Id, string name, double MaxMark, double Weight);