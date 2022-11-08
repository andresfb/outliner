namespace Outliner.UI.CLI.Menus;

public class MenuItem
{
    public int Option { get; set; }
    public Type? Assembly { get; set; }
    public string? CallClass { get; set; }
    public string? CallMethod { get; set; }
    public string? Title { get; set; }
}