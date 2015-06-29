using System.Data;

namespace Erp.Custom.SecurityAuth.Models
{
    public class TeamMemberModel
    {
        #region Properties

        public string Company { get; set; }

        public string Plant { get; set; }

        public int TreeViewId { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string TeamCode { get; set; }

        #endregion Properties

        #region Methods

        public virtual void DataBind(DataRow row)
        {
            this.TreeViewId = (int)row["TreeViewId"].GetInt();
            this.UserId = (string)row["UserID"].GetString();
            this.UserName = (string)row["Name"].GetString();
            this.TeamCode = (string)row["TeamId"].GetString();
        }

        #endregion Methods
    }
}