using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IFileService
{
    IEnumerable<Product> ReadFromFile();
    void WriteToFile(IEnumerable<Product> products);
}
