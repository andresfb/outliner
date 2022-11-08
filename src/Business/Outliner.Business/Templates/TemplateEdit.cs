using System.ComponentModel.DataAnnotations;
using Csla;
using Outliner.Dal;
using Outliner.Dal.Templates;

namespace Outliner.Business.Templates;

[Serializable]
public class TemplateEdit : BusinessBase<TemplateEdit>
{
    public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(nameof(Id));
    public int Id
    {
        get => GetProperty(IdProperty);
        private set => SetProperty(IdProperty, value);
    }

    public static readonly PropertyInfo<string> TitleProperty = RegisterProperty<string>(nameof(Title));
    [Required]
    [StringLength(60)]
    [MinLength(3)]
    public string Title
    {
        get => GetProperty(TitleProperty);
        set => SetProperty(TitleProperty, value);
    }

    public static readonly PropertyInfo<string> DescriptionProperty = RegisterProperty<string>(nameof(Description));
    public string Description
    {
        get => GetProperty(DescriptionProperty);
        set => SetProperty(DescriptionProperty, value);
    }
    
    public static readonly PropertyInfo<string> ClassNameProperty = RegisterProperty<string>(nameof(ClassName));
    [Required]
    [MinLength(5)]
    public string ClassName
    {
        get => GetProperty(ClassNameProperty);
        set => SetProperty(ClassNameProperty, value);
    }
    
    public static readonly PropertyInfo<string> MoreInfoProperty = RegisterProperty<string>(nameof(MoreInfo));
    public string MoreInfo
    {
        get => GetProperty(MoreInfoProperty);
        set => SetProperty(MoreInfoProperty, value);
    }
    
    public static readonly PropertyInfo<DateTime?> CreatedAtProperty = RegisterProperty<DateTime?>(nameof(CreatedAt));
    public DateTime? CreatedAt
    {
        get => GetProperty(CreatedAtProperty);
        private set => SetProperty(CreatedAtProperty, value);
    }
    
    public static readonly PropertyInfo<DateTime?> UpdatedAtProperty = RegisterProperty<DateTime?>(nameof(UpdatedAt));
    public DateTime? UpdatedAt
    {
        get => GetProperty(UpdatedAtProperty);
        private set => SetProperty(UpdatedAtProperty, value);
    }
    
    [Create]
    [RunLocal]
    private void Create()
    {
        Id = -1;
        base.Child_Create();
    }

    [Fetch]
    private void Fetch(int id, [Inject]IBaseDal<TemplateEntity> dal)
    {
        var data = dal.Get(id);
        using (BypassPropertyChecks)
            Csla.Data.DataMapper.Map(data, this);
        BusinessRules.CheckRules();
    }

    [Insert]
    private void Insert([Inject]IBaseDal<TemplateEntity> dal)
    {
        using (BypassPropertyChecks)
        {
            var data = LoadEntity();
            var result = dal.Insert(data);
            Id = result.Id;
        }
    }

    [Update]
    private void Update([Inject]IBaseDal<TemplateEntity> dal)
    {
        using (BypassPropertyChecks)
        {
            var data = LoadEntity();
            data.Id = Id;
            dal.Update(data);
        }
    }

    [DeleteSelf]
    private void DeleteSelf([Inject]IBaseDal<TemplateEntity> dal)
    {
        Delete(ReadProperty(IdProperty), dal);
    }

    [Delete]
    private void Delete(int id, [Inject]IBaseDal<TemplateEntity> dal)
    {
        dal.Delete(id);
    }

    private TemplateEntity LoadEntity()
    {
        return new TemplateEntity
        {
            Title = Title,
            Description = Description,
            ClassName = ClassName,
            MoreInfo = MoreInfo,
        };
    }
}