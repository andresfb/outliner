using Csla;
using Outliner.Dal.Projects;

namespace Outliner.Business.Projects;

[Serializable]
public class ProjectInfo : ReadOnlyBase<ProjectInfo>
{
    public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(nameof(Id));

    public int Id
    {
        get => GetProperty(IdProperty);
        private set => LoadProperty(IdProperty, value);
    }

    public static readonly PropertyInfo<string> TitleProperty = RegisterProperty<string>(nameof(Title));

    public string Title
    {
        get => GetProperty(TitleProperty);
        private set => LoadProperty(TitleProperty, value);
    }

    public static readonly PropertyInfo<string> SubTitleProperty = RegisterProperty<string>(nameof(SubTitle));

    public string SubTitle
    {
        get => GetProperty(SubTitleProperty);
        private set => LoadProperty(SubTitleProperty, value);
    }

    public static readonly PropertyInfo<string> ThemeProperty = RegisterProperty<string>(nameof(Theme));

    public string Theme
    {
        get => GetProperty(ThemeProperty);
        private set => LoadProperty(ThemeProperty, value);
    }
    
    public static readonly PropertyInfo<string> GenreProperty = RegisterProperty<string>(nameof(Genre));
    
    public string Genre
    {
        get => GetProperty(GenreProperty);
        private set => LoadProperty(GenreProperty, value);
    }

    public static readonly PropertyInfo<int> WordCountProperty = RegisterProperty<int>(nameof(WordCount));

    public int WordCount
    {
        get => GetProperty(WordCountProperty);
        private set => LoadProperty(WordCountProperty, value);
    }

    public static readonly PropertyInfo<string> TypeProperty = RegisterProperty<string>(nameof(Type));

    public string Type
    {
        get => GetProperty(TypeProperty);
        private set => LoadProperty(TypeProperty, value);
    }
    
    [FetchChild]
    private void Fetch(ProjectEntity data)
    {
        Id = data.Id;
        Title = data.Title;
        SubTitle = data.SubTitle;
        Theme = data.Theme;
        Genre = data.Genre;
        WordCount = data.WordCount;
        Type = data.Type;
    }
}