using Erp.Adapters;
using Erp.Tablesets;
using Ice.Lib;
using Ice.Lib.Framework;
using Ice.UI.Shared.UDSupport;
using System;

namespace Ice.CustomUI.PRList
{
    public class Transaction : EpiTransaction
    {
        //private Actions[] actionList;
        private bool codeChangeData;
        private bool isReadOnly;
        //private JobEntryAdapter jobAdapter;
        //private PartAdapter partAdapter;
        private string partXRefUOMCode;
        private Erp.Adapters.ReqAdapter reqAdapter;
        private EpiDataView reqDetailView;
        private EpiDataView reqHeadListView;
        private EpiDataView reqHeadView;
        private string reqUserID;
        //private RootToolsCollection tc;
        //private VendorAdapter vendorAdapter;
        //private VendorPPSearchAdapter vendorPPSearchAdapter;

        [Obsolete("The default c-tor has been obsoleted, please use c-tor overload that includes (object Sender)")]
        public Transaction()
        {
            this.reqHeadView = new EpiDataView(true, "NewRequisition", "New");
            this.reqDetailView = new EpiDataView(true, "NewLine", "New");
            this.reqHeadListView = new EpiDataView();
            this.partXRefUOMCode = "";
        }

        public Transaction(object Sender)
            : base(Sender)
        {
            this.reqHeadView = new EpiDataView(true, "NewRequisition", "New");
            this.reqDetailView = new EpiDataView(true, "NewLine", "New");
            this.reqHeadListView = new EpiDataView();
            this.partXRefUOMCode = "";
        }

        public void Update()
        {
            var ts = new ReqTableset();           
        }

    }
}