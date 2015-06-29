using Erp.Custom.Core.Session.Models;
using Erp.Custom.SecurityAuth.Models;
using System.Collections.Generic;

namespace Erp.Custom.SecurityAuth.Repositories
{
    public interface IAuth
    {
        #region Manage TreeView

        IEnumerable<TreeViewModel> GetAllTree();

        IEnumerable<TreeViewModel> GetTreeByFilter(TreeViewModel model);

        TreeViewModel GetTree(string treeName);

        TreeViewModel GetTreeByID(int treeId);

        bool CheckTeamInTree(int treeViewId, string teamId);

        bool CheckExistTree(string treeName);

        TreeViewModel SaveTree(Ice.Core.Session session, TreeViewModel model);

        #endregion Manage TreeView

        #region Manage Teams

        IEnumerable<TeamModel> GetAllTeam();

        IEnumerable<TeamModel> GetTeamByFilter(TeamModel model);

        TeamModel GetTeam(TeamModel model);

        #endregion Manage Teams

        #region Manage Hierarchy

        IEnumerable<TeamHierarchyModel> GetAllHierarchy(int viewId);

        IEnumerable<TeamHierarchyModel> GetHierarchiesByFilter(TeamHierarchyModel model);

        TeamHierarchyModel GetHierarchy(TeamHierarchyModel model);

        IEnumerable<TeamHierarchyModel> InsertTeam(Ice.Core.Session session, TeamHierarchyModel model);

        IEnumerable<TeamHierarchyModel> DeleteNode(Ice.Core.Session session, TeamHierarchyModel model);

        void DeleteRootNode(Ice.Core.Session session, int id);

        #endregion Manage Hierarchy

        #region Manage Member

        IEnumerable<TeamMemberModel> GetAllAvailable();

        IEnumerable<TeamMemberModel> GetAuthorizedByTree(int treeViewId);

        TeamMemberModel GetMember(TeamMemberModel model);

        IEnumerable<TeamMemberModel> AddAllMember(CustomSession session, List<TeamMemberModel> list, out bool IsSucces, out string msgError);

        bool AddAuthorized(Ice.Core.Session session, TeamMemberModel model);

        bool DeleteAuthorized(Ice.Core.Session session, TeamMemberModel model);

        //IEnumerable<>

        #endregion Manage Member

        IEnumerable<TreeStartModel> GetStartTreeByUser(string userId);

        IEnumerable<TreeStartModel> GetTeamByUser(string userId);

        IEnumerable<TreeStartModel> GetAllGetStartTree();

        IEnumerable<TeamHierarchyModel> GetAllTeamsLevel();

        string GetWaitingTeamById(int treeViewId, string teamId);

        string GetPreviousTeamById(int treeViewId, string teamId);

        string GetWaitingTeamByName(string treeViewName, string teamId);

        string GetTeamByUserID(string userId);

    }
}