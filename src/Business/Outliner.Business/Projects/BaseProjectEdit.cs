using System.ComponentModel.DataAnnotations;
using Csla;
using Outliner.Dal;
using Outliner.Dal.Projects;

namespace Outliner.Business.Projects;

[Serializable]
public abstract class BaseProjectEdit : BusinessBase<BaseProjectEdit>
{
    public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(nameof(Id));
    public int Id
    {
        get => GetProperty(IdProperty);
        private set => SetProperty(IdProperty, value);
    }

    public static readonly PropertyInfo<string> TitleProperty = RegisterProperty<string>(nameof(Title));
    [Required]
    [StringLength(100)]
    [MinLength(3)]
    public string Title
    {
        get => GetProperty(TitleProperty);
        set => SetProperty(TitleProperty, value);
    }

    public static readonly PropertyInfo<string> SubTitleProperty = RegisterProperty<string>(nameof(SubTitle));
    [StringLength(10)]
    [MinLength(3)]
    public string SubTitle
    {
        get => GetProperty(SubTitleProperty);
        set => SetProperty(SubTitleProperty, value);
    }

    public static readonly PropertyInfo<string> ThemeProperty = RegisterProperty<string>(nameof(Theme));
    [StringLength(100)]
    public string Theme
    {
        get => GetProperty(ThemeProperty);
        set => SetProperty(ThemeProperty, value);
    }
    
    public static readonly PropertyInfo<string> GenreProperty = RegisterProperty<string>(nameof(Genre));
    public string Genre
    {
        get => GetProperty(GenreProperty);
        set => SetProperty(GenreProperty, value);
    }

    public static readonly PropertyInfo<int> WordCountProperty = RegisterProperty<int>(nameof(WordCount));
    public int WordCount
    {
        get => GetProperty(WordCountProperty);
        set => SetProperty(WordCountProperty, value);
    }

    public static readonly PropertyInfo<string> TypeProperty = RegisterProperty<string>(nameof(Type));
    [Required]
    public string Type
    {
        get => GetProperty(TypeProperty);
        set => SetProperty(TypeProperty, value);
    }
    
    [Create]
    [RunLocal]
    private void Create()
    {
        Id = -1;
        base.Child_Create();
    }

    [Fetch]
    private void Fetch(int id, [Inject]IBaseDal<ProjectEntity> dal)
    {
        var data = dal.Get(id);
        using (BypassPropertyChecks)
            Csla.Data.DataMapper.Map(data, this);
        BusinessRules.CheckRules();
    }

    [Insert]
    private void Insert([Inject]IBaseDal<ProjectEntity> dal)
    {
        using (BypassPropertyChecks)
        {
            var data = LoadEntity();
            var result = dal.Insert(data);
            Id = result.Id;
        }
        
        FieldManager.UpdateChildren(Id);
    }

    [Update]
    private void Update([Inject]IBaseDal<ProjectEntity> dal)
    {
        using (BypassPropertyChecks)
        {
            var data = LoadEntity();
            data.Id = Id;
            dal.Update(data);
        }
        
        FieldManager.UpdateChildren(Id);
    }

    [DeleteSelf]
    private void DeleteSelf([Inject]IBaseDal<ProjectEntity> dal)
    {
        Delete(ReadProperty(IdProperty), dal);
    }

    [Delete]
    private void Delete(int id, [Inject]IBaseDal<ProjectEntity> dal)
    {
        dal.Delete(id);
    }

    private ProjectEntity LoadEntity()
    {
        return new ProjectEntity
        {
            Title = Title,
            // TODO map the rest of the properties
        };
    }
}