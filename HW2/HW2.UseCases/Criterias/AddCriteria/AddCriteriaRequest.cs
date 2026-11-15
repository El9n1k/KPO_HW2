namespace HW2.HW2.UseCases.Criterias.AddCriteria;

public sealed record AddCriteriaRequest(
    string Name, double MaxMark, double Weight);