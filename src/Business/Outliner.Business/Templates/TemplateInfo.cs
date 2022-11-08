using Csla;
using Outliner.Dal.Templates;

namespace Outliner.Business.Templates;

[Serializable]
public class TemplateInfo : ReadOnlyBase<TemplateInfo>
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

    public static readonly PropertyInfo<string> DescriptionProperty = RegisterProperty<string>(nameof(Description));
    public string Description
    {
        get => GetProperty(DescriptionProperty);
        private set => LoadProperty(DescriptionProperty, value);
    }
    
    public static readonly PropertyInfo<string> ClassNameProperty = RegisterProperty<string>(nameof(ClassName));
    public string ClassName
    {
        get => GetProperty(ClassNameProperty);
        private set => LoadProperty(ClassNameProperty, value);
    }
    
    public static readonly PropertyInfo<string> MoreInfoProperty = RegisterProperty<string>(nameof(MoreInfo));
    public string MoreInfo
    {
        get => GetProperty(MoreInfoProperty);
        private set => LoadProperty(MoreInfoProperty, value);
    }
    
    [FetchChild]
    private void Fetch(TemplateEntity data)
    {
        Id = data.Id;
        Title = data.Title;
        Description = data.Description;
        ClassName = data.ClassName;
        MoreInfo = data.MoreInfo;
    }
}