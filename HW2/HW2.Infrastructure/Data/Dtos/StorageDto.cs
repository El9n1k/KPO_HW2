namespace HW2.HW2.Infrastructure.Data.Dtos;

internal sealed class StorageDto
{
    public Dictionary<Guid, StudentDto> Students { get; set; } = [];
    public Dictionary<Guid, CriteriaDto> Criterias { get; set; } = [];
    public Dictionary<Guid, EvaluationDto> Evaluations { get; set; } = [];
}