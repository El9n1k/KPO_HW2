using HW2.HW2.Infrastructure.Data.Dtos;
using HW2.HW2.Models;
using HW2.HW2.UseCases.Evaluations.ListEvaluations;

namespace HW2.HW2.Infrastructure.Data.Evaluations;

internal sealed class ListEvaluationsRepository(IDataStorage storage) : IListEvaluationsRepository
{
    public IReadOnlyList<Evaluation> GetAllEvaluations()
    {
        StorageDto database = storage.Load();
        List<Evaluation> answer = [];
        foreach (var evaluation in database.Evaluations)
        {
            answer.Add(evaluation.Value.ToDomain(database.Criterias));
        }
        return answer;
    }

    public IReadOnlyDictionary<Guid, Student> GetAllStudents()
    {
        StorageDto database = storage.Load();
        Dictionary<Guid, Student> answer = [];
        foreach (var studentDto in database.Students)
        {
            Student student = studentDto.Value.ToDomain();
            answer[student.Id] = student;
        }
        return answer;
    }

    public IReadOnlyDictionary<Guid, Criteria> GetAllCriterias()
    {
        StorageDto database = storage.Load();
        Dictionary<Guid, Criteria> answer = [];
        foreach (var criteriaDto in database.Criterias)
        {
            Criteria criteria = criteriaDto.Value.ToDomain();
            answer[criteria.Id] = criteria;
        }
        return answer;
    }
}