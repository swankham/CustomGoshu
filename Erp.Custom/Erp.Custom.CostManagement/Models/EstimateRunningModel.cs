using System;
using System.Data;

namespace Erp.Custom.CostManagement.Models
{
    public class EstimateRunningModel
    {
        public string Company { get; set; }

        public string TeamId { get; set; }

        public string TeamName { get; set; }

        public int ReviseNo { get; set; }

        public string EstimateNo { get; set; }

        public string RevisionStr { get; set; }

        public int QuoteNumber { get; set; }

        public int RunningNo { get; set; }

        public DateTime GennerateDate { get; set; }

        public string GeneratedPerson { get; set; }

        public virtual void DataBind(DataRow row)
        {
            this.Company = (string)row["Company"].GetString();
            this.TeamId = (string)row["Key4"].GetString();
            this.QuoteNumber = Convert.ToInt32(Convert.ToInt32(string.IsNullOrEmpty(row["ShortChar04"].GetString()) ? "0" : row["ShortChar04"].GetString()));
            this.EstimateNo = (string)row["Key1"].GetString();
            this.RunningNo = Convert.ToInt32(string.IsNullOrEmpty(row["Key3"].GetString()) ? "0" : row["Key3"].GetString());
            this.ReviseNo = (int)row["Number02"].GetInt();
            this.GennerateDate = (DateTime)row["Date01"].GetDate();
            this.GeneratedPerson = (string)row["Key5"].GetString();
            this.RevisionStr = string.IsNullOrEmpty(row["Key2"].GetString()) ? "" : row["Key2"].GetString();
        }
    }
}