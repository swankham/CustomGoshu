using Erp.Custom.Core.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Erp.Custom.CostManagement.Models
{
    public class CostRequestModel
    {
        public string Company { get; set; }

        public string EstimateNo { get; set; }

        /// <summary>
        /// If [true] send to cost estimation.
        /// If [false] send to sale for order entry.
        /// </summary>
        public bool EstimateByCostFlag { get; set; }

        /// <summary>
        /// If [true] send to tree flow.
        /// </summary>
        //public bool EstimateByOwner { get; set; }

        public string ForSaleTypeStr
        {
            get
            {
                return (EstimateByCostFlag == false) ? "Sales" : "Service";
            }
        }

        public int ReviseNo { get; set; }

        public int RunningNo { get; set; }

        public string RevisionStr { get; set; }

        public string RequestBy { get; set; }

        public DateTime RequestDate { get; set; }

        public string CustID { get; set; }

        public string CustomerName { get; set; }

        public bool GKCStadardFlag { get; set; }

        public bool JisFlag { get; set; }

        public bool ANSFlag { get; set; }

        public bool CustomerSpecFlag { get; set; }

        public bool DinFlag { get; set; }

        public bool OtherFlag { get; set; }

        [RequiredIf("OtherFlag", true, ValueComparison.IsEqual, ErrorMessage = "Please enter other remark.")]
        public string OtherRemark { get; set; }

        public string Ref_ProjectID { get; set; }

        [RequiredIf("EstimateByCostFlag", true, ValueComparison.IsEqual, ErrorMessage = "Please enter project name.")]
        public string ProjectName { get; set; }

        public string Remarks { get; set; }

        public decimal Budget { get; set; }

        public string Location { get; set; }

        public string TeamId { get; set; }

        public int QuoteNumber { get; set; }

        public string FlowsheetFilePath { get; set; }

        public string LayoutFilePath { get; set; }

        //[RequiredIf("CustomerSpecFlag", true, ValueComparison.IsEqual, ErrorMessage = "Please choose file for specification.")]
        public string SpecFilePath { get; set; }

        public string OtherFilePath { get; set; }

        public virtual void DataBind(DataRow row)
        {
            this.Company = (string)row["Company"].GetString();
            this.EstimateNo = (string)row["Key1"].GetString();
            this.EstimateByCostFlag = Convert.ToBoolean(row["CheckBox07"].GetInt());
            //this.EstimateByOwner = Convert.ToBoolean(row["CheckBox08"].GetInt());
            this.ReviseNo = Convert.ToInt32(row["Number02"].GetInt());
            this.RunningNo = Convert.ToInt32(string.IsNullOrEmpty(row["Key3"].GetString()) ? "0" : row["Key3"].GetString());
            this.RevisionStr = string.IsNullOrEmpty(row["Key2"].GetString()) ? "" : row["Key2"].GetString();
            this.RequestBy = (string)row["Key5"].GetString();
            this.CustomerName = (string)row["ShortChar01"].GetString();
            this.RequestDate = (DateTime)row["Date01"].GetDate();
            this.GKCStadardFlag = Convert.ToBoolean(row["CheckBox01"].GetInt());
            this.JisFlag = Convert.ToBoolean(row["CheckBox02"].GetInt());
            this.ANSFlag = Convert.ToBoolean(row["CheckBox03"].GetInt());
            this.CustomerSpecFlag = Convert.ToBoolean(row["CheckBox04"].GetInt());
            this.DinFlag = Convert.ToBoolean(row["CheckBox05"].GetInt());
            this.OtherFlag = Convert.ToBoolean(row["CheckBox06"].GetInt());
            this.OtherRemark = (string)row["Character03"].GetString();
            this.Ref_ProjectID = (string)row["ShortChar02"].GetString();
            this.ProjectName = (string)row["Character01"].GetString();
            this.Remarks = (string)row["Character04"].GetString();
            this.Budget = (decimal)row["Number01"].GetDecimal();
            this.Location = (string)row["Character05"].GetString();
            this.TeamId = (string)row["Key4"].GetString();
            this.QuoteNumber = Convert.ToInt32(string.IsNullOrEmpty(row["ShortChar04"].GetString()) ? "0" : row["ShortChar04"].GetString());
        }
    }
}