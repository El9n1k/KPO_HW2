using HW2.HW2.Infrastructure.Data.Dtos;
using HW2.HW2.Models;
using Riok.Mapperly.Abstractions;

namespace HW2.HW2.Infrastructure.Data;

[Mapper]
internal static partial class DataMapper
{
    public static partial StudentDto ToDto(this Student student);
    public static partial Student ToDomain(this StudentDto dto);

    public static partial CriteriaDto ToDto(this Criteria criteria);
    public static partial Criteria ToDomain(this CriteriaDto dto);

    [MapProperty(nameof(Evaluation.Id), nameof(EvaluationDto.EvaluationId))]
    [MapProperty("Mark.Value", nameof(EvaluationDto.Mark))]
    public static partial EvaluationDto ToDto(this Evaluation evaluation);

    public static Evaluation ToDomain(this EvaluationDto dto, IReadOnlyDictionary<Guid, CriteriaDto> criterias)
    {
        if (!criterias.TryGetValue(dto.CriteriaId, out CriteriaDto? criteria))
        {
            throw new InvalidDataException(
                $"Оценка {dto.EvaluationId} ссылается на неизвестный критерий {dto.CriteriaId}");
        }

        return new Evaluation(dto.EvaluationId, dto.StudentId, criteria.ToDomain(), new Mark(dto.Mark));
    }
}