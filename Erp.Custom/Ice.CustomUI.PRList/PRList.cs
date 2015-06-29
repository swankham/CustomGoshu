using Erp.Custom.SecurityAuth.Repositories;
using Ice.Lib.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ice.CustomUI.PRList
{
    public partial class PRList : EpiBaseForm
    {
        private Ice.Core.Session epiSession;
        private Transaction trans;
        private readonly IRequisition _repo;
        private readonly IAuth _repoAth;

        public PRList(EpiTransaction iTrans)
            : base(iTrans)
        {
            InitializeComponent();
            this.trans = (Transaction)iTrans;
            this._repo = new RequisitionRepo();
            this._repoAth = new AuthRepo();
            this.epiSession = ((Ice.Core.Session)oTransaction.Session);
        }

        public PRList(Win2WebArgs args)
        {
            this.InitializeComponent();
        }

        private void PRList_Load(object sender, EventArgs e)
        {
            var teams = _repoAth.GetTeamByUser(epiSession.UserID).ToList();
            var l = (from item in teams
                     select item.TeamId + "#" + item.TreeViewId);

            var i = (from item in teams
                     select item.TeamId);

            string ts = String.Join("','", l);
            string ti = String.Join("','", i);

            var result = _repo.GetAll(ts, ti).ToList();
            SetGrid(result);
        }

        private void SetGrid(List<ReqHeadModel> list)
        {
            dgvList.Rows.Clear();
            foreach (var item in list)
            {
                dgvList.Rows.Add(item.ReqNum, item.RequestDate, item.RequestorID, item.RequestorName, item.TreeViewId, item.ActionTree, item.StatusStr, item.WaitForApproval, item.Remark);
            }
        }

        private void butDispatch_Click(object sender, EventArgs e)
        {
            ReqHeadModel reqHead = new ReqHeadModel();
            ApprovalModel model = new ApprovalModel();
            model.OrderNum = dgvList.CurrentRow.Cells["requisition"].Value.ToString().Trim();
            model.ActionTreeId = Convert.ToInt32(dgvList.CurrentRow.Cells["treeviewid"].Value);
            model.WaitForApproveTeamId = dgvList.CurrentRow.Cells["actionteam"].Value.ToString();
            model.DispatcherRemark = dgvList.CurrentRow.Cells["remark"].Value.ToString();

            reqHead = _repo.GetByID(Convert.ToInt32(model.OrderNum));

            using (Approval frm = new Approval(epiSession, model, reqHead))
            {
                frm.ShowDialog();
            }

            PRList_Load(sender, e);
        }

        private void dgvList_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
        }

        private void dgvList_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            txtNote.Text = dgvList.CurrentRow.Cells["remark"].Value.ToString();
        }

        private void butTraker_Click(object sender, EventArgs e)
        {
            int reqNum = Convert.ToInt32(dgvList.CurrentRow.Cells["requisition"].Value.GetString().Trim());
            LaunchFormOptions launchOpts = new LaunchFormOptions
            {
                ValueIn = reqNum,
                Like = "ReqHead.ReqNum"
            };
            ProcessCaller.LaunchTracker(this, "PMGO2062", launchOpts);
        }
    }
}