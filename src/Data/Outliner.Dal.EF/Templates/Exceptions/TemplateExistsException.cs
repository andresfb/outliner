using Outliner.Shared.Abstractions.Exceptions;

namespace Outliner.Dal.EF.Templates.Exceptions;

public class TemplateExistsException : OutlinerException
{
    public int Id { get; }

    public TemplateExistsException(int id) : base($"template with Id: {id} already exists")
    {
        Id = id;
    }
}