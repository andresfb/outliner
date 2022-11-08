using Csla;
using Outliner.Business.Templates;

namespace Outliner.UI.CLI.Menus.ListTemplates;

public class Menu : BaseMenu, IMenu
{
    public Menu(IDataPortalFactory factory) : base(factory)
    { }

    public void ShowMenu()
    {
        var list = Factory.GetPortal<TemplateList>().Fetch();
    }
}