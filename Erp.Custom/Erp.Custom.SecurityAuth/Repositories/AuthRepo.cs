using Erp.Custom.Core.DataService.SQL;
using Erp.Custom.Core.Session.Models;
using Erp.Custom.SecurityAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Erp.Custom.SecurityAuth.Repositories
{
    public class AuthRepo : IAuth
    {
        public IEnumerable<TreeViewModel> GetAllTree()
        {
            string sql = @"SELECT * FROM Custom_Tree  NOLOCK ORDER BY TreeViewId";
            return Repository.Instance.GetMany<TreeViewModel>(sql);
        }

        public IEnumerable<TreeViewModel> GetTreeByFilter(TreeViewModel model)
        {
            IEnumerable<TreeViewModel> query = GetAllTree();

            if (model.TreeViewName != null) { query = query.Where(p => p.TreeViewName.Contains(model.TreeViewName.ToString())); }
            return query;
        }

        public TreeViewModel GetTree(string treeName)
        {
            string sql = string.Format(@"SELECT * FROM Custom_Tree  NOLOCK WHERE TreeViewName = '{0}'", treeName);
            return Repository.Instance.GetOne<TreeViewModel>(sql);
        }

        public TreeViewModel GetTreeByID(int treeId)
        {
            string sql = string.Format(@"SELECT * FROM Custom_Tree  NOLOCK WHERE TreeViewId = {0}", treeId);
            return Repository.Instance.GetOne<TreeViewModel>(sql);
        }

        public bool CheckTeamInTree(int treeViewId, string teamId)
        {
            string sql = string.Format(@"SELECT * FROM Custom_TeamNode WHERE TreeViewId = {0} AND TeamId = '{1}'", treeViewId, teamId);
            var result = Repository.Instance.GetOne<string>(sql, "TeamId");
            return !string.IsNullOrEmpty(result);
        }

        public bool CheckExistTree(string treeName)
        {
            string sql = string.Format(@"SELECT * FROM Custom_Tree (NOLOCK) WHERE TreeViewName = '{0}'", treeName);
            var result = Repository.Instance.GetOne<string>(sql, "Check Tree");
            return !string.IsNullOrEmpty(result);
        }

        public TreeViewModel SaveTree(Ice.Core.Session session, TreeViewModel model)
        {
            string sql = string.Format(@"IF NOT EXISTS
                                         (
                                           SELECT * FROM Custom_Tree (NOLOCK) WHERE TreeViewName = '{0}'
                                         )
                                           BEGIN
                                            INSERT INTO Custom_Tree
                                                       (TreeViewName
                                                       ,Description
                                                       ,VisibleFlag
                                                       ,CreateBy
                                                       ,LastUpdateBy)
                                                 VALUES
                                                       ( '{0}' --<TreeViewName, nvarchar(100),>
                                                       , '{1}'--<Description, nvarchar(max),>
                                                       ,  {2} --<VisibleFlag, int,>
                                                       , '{3}'--<CreateBy, nvarchar(50),>
                                                       , '{3}'--<LastUpdateBy, nvarchar(50),>
                                                       )
                                            END
                                        ELSE
                                            BEGIN
                                                UPDATE Custom_Tree
                                                   SET TreeViewName = '{0}' --<TreeViewName, nvarchar(100),>
                                                      ,Description = '{1}' --<Description, nvarchar(max),>
                                                      ,VisibleFlag = {2} --<VisibleFlag, int,>
                                                      ,LastUpdateBy = '{3}' --<LastUpdateBy, nvarchar(50),>
                                                 WHERE TreeViewName = '{0}'
	                                        END" + Environment.NewLine
                                            , model.TreeViewName
                                            , model.Description
                                            , model.VisibleFlag
                                            , session.UserID);

            Repository.Instance.ExecuteWithTransaction(sql, "Delete Invoice");

            return GetTree(model.TreeViewName);
        }

        public IEnumerable<TeamModel> GetAllTeam()
        {
            string sql = @"SELECT * FROM Ice.UD06 NOLOCK ORDER BY Key1";
            return Repository.Instance.GetMany<TeamModel>(sql);
        }

        public IEnumerable<TeamModel> GetTeamByFilter(TeamModel model)
        {
            IEnumerable<TeamModel> query = GetAllTeam();

            if (model.TeamId != null) { query = query.Where(p => p.TeamId.Contains(model.TeamId.ToString())); }
            if (model.TeamName != null) { query = query.Where(p => p.TeamName.Contains(model.TeamName.ToString())); }
            if (model.Authorized != null) { query = query.Where(p => p.Authorized.Contains(model.Authorized.ToString())); }
            return query;
        }

        public TeamModel GetTeam(TeamModel model)
        {
            string sql = string.Format(@"SELECT * FROM Ice.UD06 NOLOCK WHERE Key1='{0}'", model.TeamId);
            return Repository.Instance.GetOne<TeamModel>(sql);
        }

        public IEnumerable<TeamHierarchyModel> GetAllHierarchy(int viewId)
        {
            string sql = string.Format(@" SELECT * FROM
                                            (SELECT n.TreeViewId, n.TeamId, CONVERT(varchar(30), n.TreeViewId) as ParentId, 0 as Level
                                                FROM Custom_TeamNode n WHERE n.ParentId = '{0}' AND n.TreeViewId = {0}
                                              UNION ALL
                                              SELECT n.TreeViewId, n.TeamId, n.ParentId, n.Level
                                                FROM Custom_AuthTree n WHERE n.Level != 0 AND n.TreeViewId = {0}) tmp
                                            WHERE tmp.Level <= 1", viewId);

            return Repository.Instance.GetMany<TeamHierarchyModel>(sql);
        }

        public IEnumerable<TeamHierarchyModel> GetHierarchiesByFilter(TeamHierarchyModel model)
        {
            throw new NotImplementedException();
        }

        public TeamHierarchyModel GetHierarchy(TeamHierarchyModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeamHierarchyModel> InsertTeam(Ice.Core.Session session, TeamHierarchyModel model)
        {
            string sql = string.Format(@"INSERT INTO Custom_TeamNode
                                                   (TreeViewId
                                                   ,TeamId
                                                   ,ParentId
                                                   ,VisibleFlag
                                                   ,CreateBy
                                                   ,LastUpdateBy)
                                             VALUES
                                                   ( {0} --<TreeViewId, int,>
                                                   , '{1}' --<TeamId, nvarchar(50),>
                                                   , '{2}' --<ParentId, nvarchar(50),>
                                                   , {3} --<VisibleFlag, int,>
                                                   , '{4}' --<CreateBy, nvarchar(50),>
                                                   , '{4}')" + Environment.NewLine
                                                            , model.TreeViewId
                                                            , model.TeamId
                                                            , model.ParentId
                                                            , 1
                                                            , session.UserID);
            Repository.Instance.ExecuteWithTransaction(sql, "Add node");
            return GetAllHierarchy(model.TreeViewId);
        }

        public IEnumerable<TeamHierarchyModel> DeleteNode(Ice.Core.Session session, TeamHierarchyModel model)
        {
            string sql = string.Format(@"DELETE FROM Custom_AuthTree WHERE TreeViewId = {0} AND TeamId = '{1}' " + Environment.NewLine
                                                            , model.TreeViewId
                                                            , model.TeamId);

            sql = sql + string.Format(@"DELETE FROM Custom_TeamNode WHERE TreeViewId = {0} AND TeamId = '{1}' " + Environment.NewLine
                                                , model.TreeViewId
                                                , model.TeamId);

            sql = sql + string.Format(@"DELETE FROM Custom_Authorized WHERE TreeViewId = {0} AND TeamId = '{1}' " + Environment.NewLine
                                                , model.TreeViewId
                                                , model.TeamId);

            Repository.Instance.ExecuteWithTransaction(sql, "Delete node");
            return GetAllHierarchy(model.TreeViewId);
        }


        public void DeleteRootNode(Ice.Core.Session session, int id)
        {
            string sql = string.Format(@"DELETE FROM Custom_Tree WHERE TreeViewId = {0} " + Environment.NewLine
                                                , id);

            Repository.Instance.ExecuteWithTransaction(sql, "Delete root");
        }


        public IEnumerable<TeamMemberModel> GetAllAvailable()
        {
            string sql = @"SELECT 0 as TreeViewId, DcdUserID as UserId, Name, TeamCode_c as TeamId
                                FROM UserFile NOLOCK ORDER BY DcdUserID";
            return Repository.Instance.GetMany<TeamMemberModel>(sql);
        }

        public IEnumerable<TeamMemberModel> GetAuthorizedByTree(int treeViewId)
        {
            string sql = string.Format(@"SELECT auth.TreeViewId, auth.UserId, usr.Name, auth.TeamId
                                            FROM Custom_Authorized auth 
                                            LEFT JOIN UserFile usr ON(auth.UserId = usr.DcdUserId)
                                            WHERE TreeViewId = {0}", treeViewId);
            return Repository.Instance.GetMany<TeamMemberModel>(sql);
        }

        public TeamMemberModel GetMember(TeamMemberModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeamMemberModel> AddAllMember(CustomSession session, List<TeamMemberModel> list, out bool IsSucces, out string msgError)
        {
            try
            {
                Ice.Core.Session curr = new Ice.Core.Session(session.UserId, session.Password
                        , session.AppServerURL
                        , Ice.Core.Session.LicenseType.Default);

                //UD07Tableset myUD = new UD07Tableset();

                //UD07DataSet
                IsSucces = true;
                msgError = "";
            }
            catch (Exception ex)
            {
                IsSucces = false;
                msgError = ex.Message;
            }

            return null;
        }

        public bool AddAuthorized(Ice.Core.Session session, TeamMemberModel model)
        {
            string sql = string.Format(@"IF NOT EXISTS
                                         (
                                           SELECT * FROM Custom_Authorized (NOLOCK) WHERE TreeViewId = {0} AND TeamId = '{1}' AND UserId = '{2}'
                                         )
                                            BEGIN
                                                INSERT INTO Custom_Authorized
                                                           (TreeViewId
                                                           ,TeamId
                                                           ,UserId
                                                           ,VisibleFlag
                                                           ,CreateBy
                                                           ,LastUpdateBy)
                                                     VALUES
                                                           ( {0} --<TreeViewId, int,>
                                                           , '{1}' --<TeamId, nvarchar(100),>
                                                           , '{2}' --<UserId, nvarchar(100),>
                                                           , 1 --<VisibleFlag, int,>
                                                           , '{3}' --<CreateBy, nvarchar(50),>
                                                           , '{3}' --<LastUpdateBy, nvarchar(50),>
                                                           )
                                            END
                                        ELSE
                                            BEGIN
                                                UPDATE Custom_Authorized
                                                    SET TreeViewId = {0} --<TreeViewId, int,>
                                                        ,TeamId = '{1}' --<TeamId, nvarchar(100),>
                                                        ,UserId = '{2}' --<UserId, nvarchar(100),>
                                                        ,VisibleFlag = 1 --<VisibleFlag, int,>
                                                        ,LastUpdateBy = '{3}' --<LastUpdateBy, nvarchar(50),>
                                                        WHERE TreeViewId = {0} AND TeamId = '{1}' AND UserId = '{2}'
	                                        END" + Environment.NewLine
                                            , model.TreeViewId
                                            , model.TeamCode
                                            , model.UserId
                                            , session.UserID);

            Repository.Instance.ExecuteWithTransaction(sql, "Add Authorized");

            return true;
        }


        public bool DeleteAuthorized(Ice.Core.Session session, TeamMemberModel model)
        {
            string sql = string.Format(@"DELETE FROM Custom_Authorized WHERE TreeViewId = {0} AND TeamId = '{1}' AND UserId = '{2}'" + Environment.NewLine
                                            , model.TreeViewId
                                            , model.TeamCode
                                            , model.UserId);

            Repository.Instance.ExecuteWithTransaction(sql, "Delete Authorized");

            return true;
        }


        public IEnumerable<TreeStartModel> GetStartTreeByUser(string userId)
        {
            string sql = string.Format(@"SELECT auth.TreeViewId, tree.TreeViewName, max(auth.TeamId) as TeamId, auth.UserId, team.TeamId as RootTeamId, max(atht1.Level) as CurrentLevel
                                          FROM Custom_Authorized auth
                                          LEFT JOIN Custom_Tree tree ON(auth.TreeViewId = tree.TreeViewId)
                                          LEFT JOIN Custom_TeamNode team ON(auth.TreeViewId = team.TreeViewId AND CONVERT(nvarchar(10),team.TreeViewId) = team.ParentId)
                                          INNER JOIN Custom_AuthTree atht1 ON(auth.TreeViewId = atht1.TreeViewId AND auth.TeamId = atht1.TeamId AND team.TeamId = atht1.ParentId)
                                          WHERE auth.VisibleFlag = 1 
                                          AND auth.UserId = '{0}'
                                        GROUP BY tree.TreeViewName, auth.TreeViewId, auth.UserId, auth.TeamId, team.TeamId", userId);

            return Repository.Instance.GetMany<TreeStartModel>(sql);
        }

        public IEnumerable<TreeStartModel> GetTeamByUser(string userId)
        {
            string sql = string.Format(@"SELECT auth.TreeViewId, tree.TreeViewName, max(auth.TeamId) as TeamId, auth.UserId, team.TeamId as RootTeamId, max(atht1.Level) as CurrentLevel
                                          FROM Custom_Authorized auth
                                          LEFT JOIN Custom_Tree tree ON(auth.TreeViewId = tree.TreeViewId)
                                          LEFT JOIN Custom_TeamNode team ON(auth.TreeViewId = team.TreeViewId AND CONVERT(nvarchar(10),team.TreeViewId) = team.ParentId)
                                          INNER JOIN Custom_AuthTree atht1 ON(auth.TreeViewId = atht1.TreeViewId AND auth.TeamId = atht1.TeamId AND team.TeamId = atht1.ParentId)
                                          WHERE auth.VisibleFlag = 1 
                                          AND auth.UserId = '{0}'
                                        GROUP BY tree.TreeViewName, auth.TreeViewId, auth.UserId, team.TeamId, atht1.Level", userId);

            return Repository.Instance.GetMany<TreeStartModel>(sql);
        }

        public IEnumerable<TreeStartModel> GetAllGetStartTree()
        {
            string sql = @"SELECT TreeViewId, TreeViewName, '' as TeamId, '' as UserId, '' as RootTeamId, 0 as CurrentLevel FROM Custom_Tree WHERE VisibleFlag = 1 ";

            return Repository.Instance.GetMany<TreeStartModel>(sql);
        }

        public IEnumerable<TeamHierarchyModel> GetAllTeamsLevel()
        {
            string sql = string.Format(@"SELECT * FROM Custom_AuthTree 
                                            ORDER BY TreeViewId, TeamId ASC");

            return Repository.Instance.GetMany<TeamHierarchyModel>(sql);
        }

        public string GetWaitingTeamById(int treeViewId, string teamId)
        {
            var result = this.GetAllTeamsLevel().Where(x => x.TreeViewId.Equals(treeViewId) && x.TeamId.Equals(teamId) && x.Level.Equals(1)).FirstOrDefault();
            string rs = string.Empty;
            if (result != null) rs = result.ParentId;
            return rs;
        }

        public string GetPreviousTeamById(int treeViewId, string teamId)
        {
            var result = this.GetAllTeamsLevel().Where(x => x.TreeViewId.Equals(treeViewId) && x.ParentId.Equals(teamId) && x.Level.Equals(1)).FirstOrDefault();
            string rs = string.Empty;
            if (result != null) rs = result.TeamId;
            return rs;
        }

        public string GetWaitingTeamByName(string treeViewName, string teamId)
        {
            string sql = string.Format(@"SELECT * FROM Custom_AuthTree ath
                                            INNER JOIN Custom_Tree tre ON(ath.TreeViewId = tre.TreeViewId)
                                            WHERE tre.TreeViewName = '{0}' and TeamId = '{1}' and Level = 1", treeViewName, teamId);

            return Repository.Instance.GetOne<string>(sql, "ParentId");
        }


        public string GetTeamByUserID(string userId)
        {
            string sql = string.Format(@"SELECT ud.* FROM UserFile usr 
                                            INNER JOIN Ice.UD06 ud ON(usr.TeamCode_c = ud.Key1)
                                            WHERE 1=1 AND usr.DcdUserID = N'{0}'", userId);

            return Repository.Instance.GetOne<string>(sql, "Key1");
        }
    }
}