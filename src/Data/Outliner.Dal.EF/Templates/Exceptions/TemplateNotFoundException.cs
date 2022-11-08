using Outliner.Shared.Abstractions.Exceptions;

namespace Outliner.Dal.EF.Templates.Exceptions;

public class TemplateNotFoundException : OutlinerException
{
    public int Id { get; }

    public TemplateNotFoundException(int id) : base($"template with Id: {id} not found")
    {
        Id = id;
    }
}