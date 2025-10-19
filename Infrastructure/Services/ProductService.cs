using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private List<Product> _products = new();
    private readonly IFileService _fileService;

    public ProductService(IFileService fileService)
    {
        _fileService = fileService;
    }

    public void AddProductToList(Product product)
    {
        product.Id = Guid.NewGuid().ToString();
        _products.Add(product);
        _fileService.WriteToFile(_products);
    }

    public IEnumerable<Product> GetProductsFromList()
    {
        _products = _fileService.ReadFromFile().ToList();
        return _products.OrderBy(p => p.Name);
    }
}
