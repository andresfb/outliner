using Csla;

namespace Outliner.UI.CLI.Menus;

public abstract class BaseMenu
{
    protected readonly IDataPortalFactory Factory;

    protected BaseMenu(IDataPortalFactory factory)
    {
        Factory = factory;
    }
}