using Csla;
using Outliner.Dal;
using Outliner.Dal.Projects;

namespace Outliner.Business.Projects;

[Serializable]
public abstract class BaseProjectList : ReadOnlyListBase<BaseProjectList, BaseProjectInfo>
{
    [Fetch]
    private void Fetch([Inject]IBaseDal<ProjectEntity> dal, [Inject]IChildDataPortal<BaseProjectInfo> projectInfoPortal)
    {
        using (LoadListMode)
        {
            var data = dal.Get().Select(d => projectInfoPortal.FetchChild(d));
            AddRange(data);
        }
    } 
}