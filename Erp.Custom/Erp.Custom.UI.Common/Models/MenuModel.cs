using System.Data;

namespace Erp.Custom.UI.Common.Models
{
    public class MenuModel
    {
        public string Company { get; set; }

        public string MenuID { get; set; }

        public string MenuDesc { get; set; }

        public string ParentMenuID { get; set; }

        public int Sequence { get; set; }

        public string NameSpace { get; set; }

        public string Program { get; set; }

        public int Enabled { get; set; }

        public string SecCode { get; set; }

        public string Module { get; set; }

        public string Comment { get; set; }

        public virtual void DataBind(DataRow row)
        {
            this.Company = (string)row["Company"].GetString();
            this.MenuID = (string)row["MenuID"].GetString();
            this.MenuDesc = (string)row["MenuDesc"].GetString();
            this.ParentMenuID = (string)row["ParentMenuID"].GetString();
            this.Sequence = (int)row["Sequence"].GetInt();
            this.NameSpace = (string)row["NameSpace"].GetString();
            this.Program = (string)row["Program"].GetString();
            this.Enabled = (int)row["Enabled"].GetInt();
            this.SecCode = (string)row["SecCode"].GetString();
            this.Module = (string)row["Module"].GetString();
            this.Comment = (string)row["Comment"].GetString();
        }
    }
}