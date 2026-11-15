using HW2.HW2.Infrastructure.Data.Dtos;

namespace HW2.HW2.Infrastructure.Data;

internal interface IDataStorage
{
    StorageDto Load();
    void Save(StorageDto database);
}