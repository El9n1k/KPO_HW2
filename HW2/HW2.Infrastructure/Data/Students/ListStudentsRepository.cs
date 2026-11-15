using HW2.HW2.Models;
using HW2.HW2.UseCases.Students.ListStudents;

namespace HW2.HW2.Infrastructure.Data.Students;

internal sealed class ListStudentsRepository(IDataStorage storage) : IListStudentsRepository
{
    public IReadOnlyList<Student> GetAll()
    {
        return storage.Load().Students.Values.Select(DataMapper.ToDomain).ToList();
    }
}