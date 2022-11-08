using Csla;
using Outliner.Dal.Templates;

namespace Outliner.Business.Templates;

[Serializable]
public class TemplateList : ReadOnlyListBase<TemplateList, TemplateInfo>
{
    [Fetch]
    private void Fetch([Inject]ITemplateDal dal, [Inject]IChildDataPortal<TemplateInfo> templateInfoPortal)
    {
        using (LoadListMode)
        {
            var data = dal.Get().Select(d => templateInfoPortal.FetchChild(d));
            AddRange(data);
        }
    }   
}