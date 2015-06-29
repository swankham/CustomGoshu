using System.Data;

namespace Erp.Custom.SecurityAuth.Models
{
    public class TeamHierarchyModel
    {
        #region Properties

        public int TreeViewId { get; set; }

        public string TeamId { get; set; }

        public string ParentId { get; set; }

        public int Level { get; set; }

        #endregion Properties

        public virtual void DataBind(DataRow row)
        {
            this.TreeViewId = (int)row["TreeViewId"].GetInt();
            this.TeamId = (string)row["TeamId"].GetString();
            this.ParentId = (string)row["ParentId"].GetString();
            this.Level = (int)row["Level"].GetInt();
        }
    }
}