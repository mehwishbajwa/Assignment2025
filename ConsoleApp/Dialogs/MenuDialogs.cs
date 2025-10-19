namespace Presentation.ConsoleApp.Dialogs;

public class MenuDialogs
{
    private readonly ProductDialogs _productDialogs;

    public MenuDialogs(ProductDialogs productDialogs)
    {
        _productDialogs = productDialogs;
    }

    public void MenuOptionsDialog()
    {
        Console.Clear();
        Console.WriteLine("### MENU ###");
        Console.WriteLine("1. View Product List");
        Console.WriteLine("2. New Product");
        Console.WriteLine("0. Exit");
        Console.Write("Choose a menu option: ");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                _productDialogs.ListProductsDialog();
                break;
            case "2":
                _productDialogs.AddProductDialog();
                break;
            case "0":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option. Try again!");
                break;
        }
    }

    public void Run()
    {
        while (true)
        {
            MenuOptionsDialog();
        }
    }
}
