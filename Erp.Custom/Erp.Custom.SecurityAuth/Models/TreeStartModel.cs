using System.Data;
namespace Erp.Custom.SecurityAuth.Models
{
    /// <summary>
    /// For use in case starting approval.
    /// This model will get Tree by follow the user login id.
    /// </summary>
    public class TreeStartModel
    {
        public int TreeViewId { get; set; }

        public string TreeViewName { get; set; }

        public string TeamId { get; set; }

        public string UserId { get; set; }

        public string RootTeamId { get; set; }

        public int CurrentLevel { get; set; }

        public virtual void DataBind(DataRow row)
        {
            this.TreeViewId = (int)row["TreeViewId"].GetInt();
            this.TreeViewName = (string)row["TreeViewName"].GetString();
            this.TeamId = (string)row["TeamId"].GetString();
            this.UserId = (string)row["UserId"].GetString();
            this.RootTeamId = (string)row["RootTeamId"].GetString();
            this.CurrentLevel = (int)row["CurrentLevel"].GetInt();
        }
    }
}