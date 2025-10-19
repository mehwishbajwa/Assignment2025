using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Presentation.ConsoleApp.Dialogs;

public class ProductDialogs
{
    private readonly IProductService _productService;

    public ProductDialogs(IProductService productService)
    {
        _productService = productService;
    }

    public void AddProductDialog()
    {
        var product = new Product();

        Console.Clear();
        Console.WriteLine("### NEW PRODUCT ###");

        Console.Write("Product Name: ");
        product.Name = Console.ReadLine() ?? "";

        Console.Write("Product Price (SEK): ");
        decimal.TryParse(Console.ReadLine(), out decimal price);
        product.Price = price;

        _productService.AddProductToList(product);
        Console.WriteLine("Product added successfully!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void ListProductsDialog()
    {
        var products = _productService.GetProductsFromList();

        Console.Clear();
        Console.WriteLine("### PRODUCT LIST ###");

        foreach (var product in products)
        {
            Console.WriteLine($"Id: {product.Id}");
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Price: {product.Price} SEK");
            Console.WriteLine("---------------------");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}

