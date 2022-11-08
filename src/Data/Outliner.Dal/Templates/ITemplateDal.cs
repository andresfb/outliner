namespace Outliner.Dal.Templates;

public interface ITemplateDal
{
    bool Exists(int id);
    TemplateEntity Get(int id);
    IEnumerable<TemplateEntity> Get();
    TemplateEntity Insert(TemplateEntity person);
    TemplateEntity Update(TemplateEntity person);
    bool Delete(int id);
}