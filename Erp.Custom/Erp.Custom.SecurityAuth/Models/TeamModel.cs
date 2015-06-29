using System;
using System.Collections.Generic;
using System.Data;

namespace Erp.Custom.SecurityAuth.Models
{
    public class TeamModel
    {
        #region Constructors

        public TeamModel()
        {
            Members = new List<TeamMemberModel>();
        }

        #endregion Constructors

        #region Properties

        public string Company { get; set; }

        public string Plant { get; set; }

        public string TeamId { get; set; }

        public string TeamName { get; set; }

        public string Authorized { get; set; }

        public bool Division { get; set; }

        public bool Department { get; set; }

        public bool Section { get; set; }

        public bool Team { get; set; }

        public int VisibleFlag { get; set; }

        public string CreateBy { get; set; }

        public IList<TeamMemberModel> Members { get; set; }

        #endregion Properties

        #region Methods

        public virtual void DataBind(DataRow row)
        {
            this.TeamId = (string)row["Key1"].GetString();
            this.TeamName = (string)row["Character01"].GetString();
            this.Division = Convert.ToBoolean((int)row["CheckBox01"].GetInt());
            this.Department = Convert.ToBoolean((int)row["CheckBox02"].GetInt());
            this.Section = Convert.ToBoolean((int)row["CheckBox03"].GetInt());
            this.Team = Convert.ToBoolean((int)row["CheckBox04"].GetInt());
        }

        #endregion Methods
    }
}