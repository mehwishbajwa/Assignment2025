using Infrastructure.Models;
using Infrastructure.Interfaces;
using Newtonsoft.Json;

namespace Infrastructure.Services;

public class FileService : IFileService
{
    private static readonly string _directoryPath = @"c:\data";
    private readonly string _filePath = Path.Combine(_directoryPath, "products.json");

    public FileService()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (!Directory.Exists(_directoryPath))
            Directory.CreateDirectory(_directoryPath);

        if (!File.Exists(_filePath))
            File.WriteAllText(_filePath, "[]");
    }

    public void WriteToFile(IEnumerable<Product> products)
    {
        var json = JsonConvert.SerializeObject(products, Formatting.Indented);
        File.WriteAllText(_filePath, json);
    }

    public IEnumerable<Product> ReadFromFile()
    {
        var content = File.ReadAllText(_filePath);
        var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);
        return products ?? new List<Product>();
    }
}
