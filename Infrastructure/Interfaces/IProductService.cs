using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    void AddProductToList(Product product);
    IEnumerable<Product> GetProductsFromList();
}
