using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.Services;
using Moq;
using Xunit;

namespace Infrastructure.Tests.Services;

public class ProductService_Tests
{
    [Fact]
    public void AddProductToList_ShouldAddOneProductToList()
    {
        // Arrange
        var product = new Product { Name = "Test Product", Price = 100 };
        var fileServiceMock = new Mock<IFileService>();

        fileServiceMock.Setup(x => x.WriteToFile(It.IsAny<IEnumerable<Product>>()));
        fileServiceMock.Setup(x => x.ReadFromFile()).Returns(new List<Product> { product });

        var productService = new ProductService(fileServiceMock.Object);

        // Act
        productService.AddProductToList(product);
        var products = productService.GetProductsFromList();

        // Assert
        Assert.Single(products);
    }
}
