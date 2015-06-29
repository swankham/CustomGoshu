using Erp.Custom.Core.Session.Models;
using Erp.Custom.SecurityAuth.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Erp.Custom.SecurityAuth.Models
{
    public class TransModel
    {
        #region Fields

        private readonly IAuth _repo;

        #endregion Fields

        #region Constructors

        public TransModel()
        {
            this._repo = new AuthRepo();
            Tree = new TreeViewModel();
            Teams = new List<TeamModel>();
            Available = new List<TeamMemberModel>();
            Authorized = new List<TeamMemberModel>();
            Hierarchy = new List<TeamHierarchyModel>();
        }

        #endregion Constructors

        #region Properties

        public string Company { get; set; }

        public string Plant { get; set; }

        public TreeViewModel Tree { get; set; }

        public IList<TeamModel> Teams { get; set; }

        public IList<TeamMemberModel> Available { get; set; }

        public IList<TeamMemberModel> Authorized { get; set; }

        public IList<TeamHierarchyModel> Hierarchy { get; set; }

        #endregion Properties

        #region Methods

        public virtual void DataBind(DataRow row)
        {
            this.Company = (string)row["Company"].GetString();
            this.Plant = (string)row["Plant"].GetString();
        }

        #endregion Methods

        public void LoadData(Ice.Core.Session epiSession)
        {
            Hierarchy = _repo.GetAllHierarchy(Tree.TreeViewId).ToList();
            Teams = _repo.GetAllTeam().ToList();
            Available = _repo.GetAllAvailable().ToList();
            Authorized = _repo.GetAuthorizedByTree(Tree.TreeViewId).ToList();
        }

        public void GetNew(Ice.Core.Session epiSession)
        {
            Teams = _repo.GetAllTeam().ToList();
            Available = _repo.GetAllAvailable().ToList();
        }
    }
}