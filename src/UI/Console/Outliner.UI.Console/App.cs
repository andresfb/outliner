namespace Outliner.UI.CLI;

public class App
{
    private readonly MainMenu _mainMenu;

    public App(MainMenu mainMenu)
    {
        _mainMenu = mainMenu;
    }
    
    public void Run(string[] args)
    {
        var go = true;
        while (go)
        {
            go = _mainMenu.ShowMenu();
        }
    }
}