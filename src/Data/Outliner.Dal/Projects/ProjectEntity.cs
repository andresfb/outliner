namespace Outliner.Dal.Projects;

public class ProjectEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Theme { get; set; }
    public string Genre { get; set; }
    public int WordCount { get; set; }
    public string Type { get; set; }
}