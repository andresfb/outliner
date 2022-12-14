using Csla;
using Outliner.UI.CLI.Menus;

namespace Outliner.UI.CLI;

public class MainMenu
{
    private readonly IDataPortalFactory _factory;
    
    private readonly List<MenuItem?> _options;

    public MainMenu(IDataPortalFactory factory)
    {
        _factory = factory;
        
        var option = 1;
        _options = new List<MenuItem?>
        {
            new MenuItem
            {
                Option = option++,
                Assembly = typeof(Menus.ListTemplates.Menu),
                Title = "List available Templates"
            },
            new MenuItem
            {
                Option = option,
                Assembly = typeof(Menus.AddTemplate.Menu),
                Title = "Create new Template"
            },
        };
    }
    
    public bool ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Outliner App\n");
        Console.WriteLine("\nMain Menu");
        Console.WriteLine("----------\n\n");
        Console.WriteLine("Options:\n");
        foreach (var item in _options.Where(item => item != null))
        {
            if (item != null) Console.WriteLine($"{item.Option}. {item.Title}");
        }

        Console.WriteLine("Q. Exit");
        Console.Write("\n\nEnter the number: ");
        var value = Console.ReadLine()?.Trim().ToUpper();

        if (string.IsNullOrEmpty(value) || value == "Q")
        {
            return false;
        }

        var selection = Convert.ToInt32(value);
        if (selection == 0 || selection > _options.Count)
        {
            Console.WriteLine("Invalid Selection");
            return false;
        }

        var option = _options.FirstOrDefault(o => o != null && o.Option == selection);
        if (option == null)
        {
            Console.WriteLine("Invalid Selection");
            return false;
        }

        if (option.Assembly is null)
        {
            Console.WriteLine("Invalid Selection");
            return false;
        }
        
        if (Activator.CreateInstance(option.Assembly, _factory) is not IMenu menu)
        {
            Console.WriteLine("Invalid Selection");
            return false;
        }

        menu.ShowMenu();
        return true;
    }
}