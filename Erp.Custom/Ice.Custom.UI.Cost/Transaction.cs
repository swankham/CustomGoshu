using Ice.Lib.Framework;
using Ice.Lib.Searches;
using Ice.Tablesets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ice.Custom.UI.CostRequest
{
    public class Transaction : EpiTransaction
    {
        //private Actions[] actionList;
        private bool codeChangeData;
        private bool isReadOnly;
        //private JobEntryAdapter jobAdapter;
        //private PartAdapter partAdapter;
        private string partXRefUOMCode;
        private Ice.Adapters.UD07Adapter udAdapter;
        private EpiDataView reqHeadView;

        [Obsolete("The default c-tor has been obsoleted, please use c-tor overload that includes (object Sender)")]
        public Transaction()
        {
            this.reqHeadView = new EpiDataView(true, "NewRequisition", "New");
            this.partXRefUOMCode = "";
        }

        public Transaction(object Sender)
            : base(Sender)
        {
            this.reqHeadView = new EpiDataView(true, "NewRequisition", "New");
            this.partXRefUOMCode = "";
        }

        public void Update()
        {
            var ts = new UD07Tableset();
        }

        public void InvokeSearch(SearchOptions opts)
        {

        }


    }
}
