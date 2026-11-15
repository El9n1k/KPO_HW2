using System.Text.Json;
using HW2.HW2.Infrastructure.Data.Dtos;

namespace HW2.HW2.Infrastructure.Data;

internal sealed class JsonStorage(string filePath = "data.json") : IDataStorage
{
    private static readonly JsonSerializerOptions SerializerOptions = new() { WriteIndented = true };

    public StorageDto Load()
    {
        if (!File.Exists(filePath))
        {
            return new StorageDto();
        }

        string json = File.ReadAllText(filePath);
        if (string.IsNullOrWhiteSpace(json))
        {
            return new StorageDto();
        }

        try
        {
            StorageDto dto = JsonSerializer.Deserialize<StorageDto>(json, SerializerOptions)
                             ?? throw new InvalidDataException($"'{filePath}': файл не содержит данных");

            dto.Students ??= [];
            dto.Criterias ??= [];
            dto.Evaluations ??= [];

            return dto;
        }
        catch (JsonException ex)
        {
            throw new InvalidDataException($"'{filePath}': файл повреждён ({ex.Message})", ex);
        }
    }

    public void Save(StorageDto database)
    {
        string json = JsonSerializer.Serialize(database, SerializerOptions);
        File.WriteAllText(filePath, json);
    }
}