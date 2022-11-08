namespace Outliner.Dal.Templates;

public class TemplateEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Assembly { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}