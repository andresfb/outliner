using Outliner.UI.CLI.Menus;

namespace Outliner.UI.CLI;

public class MainMenu
{
    private readonly List<MenuItem?> options;

    public MainMenu()
    {
        var option = 1;

        options = new List<MenuItem?>
        {
            new MenuItem
            {
                Option = option++,
                CallNamespace = typeof(Menus.ListTemplates.Menu),
                Title = "List Available Templates"
            },
            // new MenuItem
            // {
            //     Option = option++,
            //     CallNamespace = "Score.Tests.Cli.MailOrder.Business",
            //     Title = "Create new Templates"
            // },
        };
    }
    
    public bool ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Outliner App\n");
        Console.WriteLine("\nMain Menu");
        Console.WriteLine("----------\n\n");
        Console.WriteLine("Options:\n");
        foreach (var item in options.Where(item => item != null))
        {
            Console.WriteLine($"{item.Option}. {item.Title}");
        }

        Console.WriteLine("Q. Exit");
        Console.Write("\n\nEnter the number: ");
        var value = Console.ReadLine()?.Trim().ToUpper();

        if (string.IsNullOrEmpty(value) || value == "Q")
        {
            return false;
        }

        var selection = Convert.ToInt32(value);
        if (selection == 0 || selection > options.Count)
        {
            Console.WriteLine("Invalid Selection");
            return false;
        }

        var option = options.FirstOrDefault(o => o.Option == selection);
        if (option == null)
        {
            Console.WriteLine("Invalid Selection");
            return false;
        }
        
        if (Activator.CreateInstance(option.CallNamespace) is not IMenu menu)
        {
            Console.WriteLine("Invalid Selection");
            return false;
        }

        menu.ShowMenu();
        return true;
    }
}