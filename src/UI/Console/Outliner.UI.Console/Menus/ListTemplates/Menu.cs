using ConsoleTables;
using Csla;
using Outliner.Business.Templates;

namespace Outliner.UI.CLI.Menus.ListTemplates;

public class Menu : BaseMenu, IMenu
{
    public Menu(IDataPortalFactory factory) : base(factory)
    { }

    public void ShowMenu()
    {
        try
        {
            var list = Factory.GetPortal<TemplateList>().Fetch();
            if (list.Count == 0)
            {
                Console.WriteLine("No Templates found");
                Console.WriteLine();
                return;
            }
        
            var table = new ConsoleTable("Id", "Title", "Description");
            foreach (var template in list)
            {
                table.AddRow(template.Id, template.Title, template.Description[..50]);
            }
        
            table.Write();
            Console.WriteLine();
        }
        finally
        {
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();   
        }
    }
}