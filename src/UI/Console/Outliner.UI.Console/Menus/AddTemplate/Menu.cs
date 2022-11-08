using Csla;
using Outliner.Business.Templates;

namespace Outliner.UI.CLI.Menus.AddTemplate;

public class Menu : BaseMenu, IMenu
{
    public Menu(IDataPortalFactory factory) : base(factory)
    { }

    public void ShowMenu()
    {
        try
        {
            Console.WriteLine();
            Console.WriteLine("Create a new Template:");
            Console.WriteLine();
            
            var template = Factory.GetPortal<TemplateEdit>().Create();
            var complete = false;
            
            while (!complete)
            {
                template.BeginEdit();
                Console.Write("Enter Title: ");
                template.Title = Console.ReadLine()?.Trim() ?? "";
                
                Console.Write("Enter Description: ");
                template.Description = Console.ReadLine()?.Trim() ?? "";
                
                Console.Write("Add a link for more info: ");
                template.MoreInfo = Console.ReadLine()?.Trim() ?? "";
                
                Console.Write("Enter Class Name: ");
                template.ClassName = Console.ReadLine()?.Trim() ?? "";

                if (!template.IsSavable)
                {
                    Console.WriteLine();
                    Console.WriteLine("Errors found on the entered data:");
                    Console.WriteLine(template.GetBrokenRules().ToString());
                    Console.WriteLine();
                    
                    template.CancelEdit();
                    continue;
                }

                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Saving...");
                    
                    template.ApplyEdit();
                    template = template.Save();
                    complete = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                    
                    template.CancelEdit();
                }
            }
            
            Console.WriteLine();
            Console.WriteLine($"Created Template {template.Title}");
            Console.WriteLine();
        }
        finally
        {
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}