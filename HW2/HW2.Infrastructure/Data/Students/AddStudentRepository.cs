using HW2.HW2.Infrastructure.Data.Dtos;
using HW2.HW2.Models;
using HW2.HW2.UseCases.Students.AddStudent;

namespace HW2.HW2.Infrastructure.Data.Students;

internal sealed class AddStudentRepository(IDataStorage storage) : IAddStudentRepository
{
    public void Add(Student student)
    {
        StorageDto database = storage.Load();
        database.Students[student.Id] = student.ToDto();
        storage.Save(database);
    }
}