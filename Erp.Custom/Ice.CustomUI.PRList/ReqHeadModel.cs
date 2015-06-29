using System;
using System.Data;

namespace Ice.CustomUI.PRList
{
    public class ReqHeadModel
    {
        public string Company { get; set; }

        public DateTime RequestDate { get; set; }

        public string ReqTime
        {
            get
            {
                return RequestDate.ToShortTimeString();
            }
        }

        public int ReqNum { get; set; }

        public string RequestorID { get; set; }

        public string RequestorName { get; set; }

        public string RequestorTeamID { get; set; }

        public string Status { get; set; }

        public int TreeViewId { get; set; }

        public string ActionTree { get; set; }

        public string StatusStr
        {
            get { return Enum.GetName(typeof(ReqStatus), Convert.ToInt32(string.IsNullOrEmpty(Status) ? "0" : Status)); }
        }

        public string WaitForApproval { get; set; }

        public string Remark { get; set; }

        public string ApprovedName { get; set; }

        public string NextActionID { get; set; }

        public string NextActionDesc { get; set; }

        public string ReplyOption { get; set; }

        public string ReqUserId { get; set; }

        public string SentByTeam { get; set; }

        public virtual void DataBind(DataRow row)
        {
            this.Company = (string)row["Company"].GetString();
            this.RequestDate = (DateTime)row["RequestDate"].GetDate();
            this.ReqNum = (int)row["ReqNum"].GetInt();
            this.RequestorID = (string)row["RequestorID"].GetString();
            this.RequestorName = (string)row["RequestorName"].GetString();
            this.Status = (string)row["Status_c"].GetString();
            this.TreeViewId = Convert.ToInt32(string.IsNullOrEmpty((string)row["TreeViewID_c"].GetString()) ? "0" : (string)row["TreeViewID_c"]);
            this.ActionTree = string.IsNullOrEmpty((string)row["ActionTree"].GetString()) ? "None" : (string)row["ActionTree"];
            this.Remark = (string)row["ReqActionDesc_c"].GetString();
            this.WaitForApproval = (string)row["WaitingTeamID_c"].GetString();
            this.SentByTeam = string.IsNullOrEmpty((string)row["SentByTeam_c"].GetString()) ? "" : (string)row["SentByTeam_c"].GetString();
        }
    }
}