using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ice.CustomUI.PRList
{
    public class BuyerModel
    {
        public string BuyerCode { get; set; }

        public string BuyerName { get; set; }

        public virtual void DataBind(DataRow row)
        {
            this.BuyerCode = (string)row["BuyerID"].GetString();
            this.BuyerName = (string)row["Name"].GetString();
        }
    }
}
