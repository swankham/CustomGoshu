using System.Data;
using System.Collections.Generic;

namespace Erp.Custom.SecurityAuth.Models
{
    public class TreeViewModel
    {
        #region Constructors

        public TreeViewModel()
        {
            TeamItems = new List<TeamHierarchyModel>();
            
        }

        #endregion Constructors

        #region Properties

        public string Company { get; set; }

        public string Plant { get; set; }

        public int TreeViewId { get; set; }

        public string TreeViewName { get; set; }

        public string Description { get; set; }

        public int VisibleFlag { get; set; }

        public string CreateBy { get; set; }

        public IList<TeamHierarchyModel> TeamItems  { get; set; }
        

        #endregion Properties

        #region Methods

        public virtual void DataBind(DataRow row)
        {
            this.TreeViewId = (int)row["TreeViewId"].GetInt();
            this.TreeViewName = (string)row["TreeViewName"].GetString();
            this.Description = (string)row["Description"].GetString();
            this.VisibleFlag = (int)row["VisibleFlag"].GetInt();
            this.CreateBy = (string)row["CreateBy"].GetString();
        }

        #endregion Methods
    }
}