using Csla;
using Outliner.Dal;
using Outliner.Dal.Projects;

namespace Outliner.Business.Projects;

[Serializable]
public class ProjectList : ReadOnlyListBase<ProjectList, ProjectInfo>
{
    [Fetch]
    private void Fetch([Inject]IBaseDal<ProjectEntity> dal, [Inject]IChildDataPortal<ProjectInfo> projectInfoPortal)
    {
        using (LoadListMode)
        {
            var data = dal.Get().Select(d => projectInfoPortal.FetchChild(d));
            AddRange(data);
        }
    } 
}