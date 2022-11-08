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
    
    public static readonly PropertyInfo<string> AssemblyProperty = RegisterProperty<string>(nameof(Assembly));
    public string Assembly
    {
        get => GetProperty(AssemblyProperty);
        private set => LoadProperty(AssemblyProperty, value);
    }
    
    public static readonly PropertyInfo<DateTime> CreatedAtProperty = RegisterProperty<DateTime>(nameof(CreatedAt));
    public DateTime CreatedAt
    {
        get => GetProperty(CreatedAtProperty);
        private set => LoadProperty(CreatedAtProperty, value);
    }
    
    public static readonly PropertyInfo<DateTime> UpdatedAtProperty = RegisterProperty<DateTime>(nameof(UpdatedAt));
    public DateTime UpdatedAt
    {
        get => GetProperty(UpdatedAtProperty);
        private set => LoadProperty(UpdatedAtProperty, value);
    }
    
    [FetchChild]
    private void Fetch(TemplateEntity data)
    {
        Id = data.Id;
        Title = data.Title;
        Description = data.Description;
        Assembly = data.Assembly;
        CreatedAt = data.CreatedAt;
        UpdatedAt = data.UpdatedAt;
    }    
}