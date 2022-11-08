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
            Console.WriteLine();
            var list = Factory.GetPortal<TemplateList>().Fetch();
            if (list.Count == 0)
            {
                Console.WriteLine("No Templates found");
                Console.WriteLine();
                return;
            }
        
            var table = new ConsoleTable("Id", "Title", "Description", "More Info");
            foreach (var template in list)
            {
                var description = template.Description.Length > 100
                    ? template.Description[..100] 
                    : template.Description;
                
                table.AddRow(template.Id, template.Title, description, template.MoreInfo);
            }
        
            Console.WriteLine();
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