using Outliner.Dal.EF.Templates.Exceptions;
using Outliner.Dal.Templates;

namespace Outliner.Dal.EF.Templates.Data;

public class TemplateDal : IBaseDal<TemplateEntity>
{
    private readonly OutlinerDbContext _context;

    public TemplateDal(OutlinerDbContext context)
    {
        _context = context;
    }
    
    public bool Exists(int id)
    {
        var person = _context.Templates.FirstOrDefault(p => p.Id == id);
        return person != null;
    }

    public TemplateEntity Get(int id)
    {
        var person = _context.Templates.FirstOrDefault(p => p.Id == id);
        return person ?? throw new TemplateNotFoundException(id);
    }

    public IEnumerable<TemplateEntity> Get()
    {
        return _context.Templates.Where(r => true).ToList();
    }

    public TemplateEntity Insert(TemplateEntity template)
    {
        if (Exists(template.Id)) throw new TemplateExistsException(template.Id);

        {
            template.CreatedAt = DateTime.Now;
            template.UpdatedAt = DateTime.Now;
            
            _context.Templates.Add(template);
            _context.SaveChanges();
            
            try
            {
                template.Id = _context.Templates.Max(m => m.Id);
            }
            catch
            {
                /* ignore exception */
            }
        }
        
        return template;
    }

    public TemplateEntity Update(TemplateEntity template)
    {
        {
            var old = Get(template.Id);
            old.Title = template.Title;
            old.Description = template.Description;
            old.ClassName = template.ClassName;
            old.MoreInfo = template.MoreInfo;
            old.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return old;
        }
    }

    public bool Delete(int id)
    {
        var template = _context.Templates.FirstOrDefault(p => p.Id == id);
        if (template == null) return false;
        _context.Templates.Remove(template);
        _context.SaveChanges();     
        return true;
    }
}