using Erp.Custom.Core.Session.Models;
using Erp.Custom.SecurityAuth.Models;
using Erp.Custom.SecurityAuth.Repositories;
using Ice.Lib.Framework;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Ice.CustomUI.PRList
{
    public partial class Approval : EpiBaseForm
    {
        private Ice.Core.Session epiSession;
        private ApprovalModel content;
        private ReqHeadModel reqHeadModel;
        private readonly IAuth _repo;
        private readonly IRequisition _repoReq;

        public Approval(Ice.Core.Session _session = null, ApprovalModel model = null, ReqHeadModel reqHead = null)
        {
            InitializeComponent();
            epiSession = _session;
            this.content = model;
            this.reqHeadModel = reqHead;
            this._repo = new AuthRepo();
            this._repoReq = new RequisitionRepo();
        }

        private void Approval_Load(object sender, EventArgs e)
        {
            content.RequestorId = epiSession.UserID;
            //content.RequestorName
            reqHeadModel.RequestorTeamID = _repo.GetTeamByUserID(reqHeadModel.RequestorID);
            rdoApprove.Checked = true;
            BindingForm(content);

            //content.DepatcherTeam = string.IsNullOrEmpty(_repo.GetWaitingTeamById(content.ActionTreeId,
            //    content.WaitForApproveTeamId)) ? "" : _repo.GetWaitingTeamById(content.ActionTreeId,
            //    content.WaitForApproveTeamId);

            //if (string.IsNullOrEmpty(content.DepatcherTeam))
            //{
            //    var result = _repoReq.GetDefualtBuyer(content.RequestorId);
            //    content.DepatcherTeam = result;
            //}
            //txtDispatcherTeam.Text = content.DepatcherTeam;
        }

        private void ClearBinding()
        {
            txtRequestor.DataBindings.Clear();
            txtDispatcherTeam.DataBindings.Clear();
            txtDispatcherRemark.DataBindings.Clear();
            txtReplyRemark.DataBindings.Clear();
            cboActionTree.DataBindings.Clear();

            txtRequestor.Clear();
            txtDispatcherTeam.Clear();
            txtDispatcherRemark.Clear();
            txtReplyRemark.Clear();
        }

        private void BindingForm(ApprovalModel model)
        {
            ClearBinding();
            txtRequestor.DataBindings.Add("Text", model, "RequestorId", false, DataSourceUpdateMode.OnPropertyChanged);
            txtDispatcherTeam.DataBindings.Add("Text", model, "DepatcherTeam", false, DataSourceUpdateMode.OnPropertyChanged);
            txtDispatcherRemark.DataBindings.Add("Text", model, "DispatcherRemark", false, DataSourceUpdateMode.OnPropertyChanged);
            txtReplyRemark.DataBindings.Add("Text", model, "ReplyRemark", false, DataSourceUpdateMode.OnPropertyChanged);

            if (model.ActionTreeId == 0)
            {
                if (reqHeadModel.RequestorID == epiSession.UserID)
                {
                    model.ActionTrees = _repo.GetStartTreeByUser(reqHeadModel.RequestorID).Where(x => x.TeamId.Equals(model.WaitForApproveTeamId)).ToList();

                    cboActionTree.Enabled = true;
                    rdoReject.Enabled = false;
                    butBuyer.Visible = false;
                }
                else
                {
                    MessageBox.Show("Requestor is not equal current user.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            else
            {
                model.ActionTrees = _repo.GetAllGetStartTree().ToList();

                var resutl = _repo.GetTreeByID(model.ActionTreeId);
                model.ActionTree = resutl.TreeViewName;
                cboActionTree.Enabled = false;
                rdoReject.Enabled = true;
                butBuyer.Visible = false;
            }

            if (model.ActionTrees.Count() != 0)
            {
                cboActionTree.DataSource = model.ActionTrees;
                cboActionTree.DisplayMember = "TreeViewName";
                cboActionTree.ValueMember = "TreeViewId";
                cboActionTree.DataBindings.Add("Text", model, "ActionTree");
            }
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (rdoApprove.Checked) content.ApproveFlag = true; else content.ApproveFlag = false;
            content.ReplyRemark = txtReplyRemark.Text;
            CustomSession sess = new CustomSession();
            sess.UserId = "manager";
            sess.Password = "manager";
            if (_repoReq.SaveApprove(sess, content, reqHeadModel)) this.Close();
        }

        private void cboActionTree_Leave(object sender, EventArgs e)
        {
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetTeam()
        {
            if (rdoApprove.Checked)
            {
                var t = (from team in content.ActionTrees
                         where team.TreeViewId.ToString().Trim() == content.ActionTreeId.ToString().Trim()
                         select team.TeamId).SingleOrDefault();
                string teamId = string.IsNullOrEmpty(t.ToString()) ? "#" : t.ToString();
                teamId = string.IsNullOrEmpty(t.ToString()) ? "#" : t.ToString();
                content.DepatcherTeam = _repo.GetWaitingTeamById(content.ActionTreeId, teamId);
            }
            else
            {
                content.DepatcherTeam = _repo.GetPreviousTeamById(content.ActionTreeId, content.WaitForApproveTeamId);
            }

            txtDispatcherTeam.Text = content.DepatcherTeam;
        }

        private void rdoApprove_Click(object sender, EventArgs e)
        {
            //GetTeam();
        }

        private void rdoReject_Click(object sender, EventArgs e)
        {
            //GetTeam();
        }

        private void butBuyer_Click(object sender, EventArgs e)
        {
            using (BuyerSearch frm = new BuyerSearch(epiSession, reqHeadModel.RequestorID))
            {
                frm.ShowDialog();
                string code = frm.Code;
                if (!string.IsNullOrEmpty(code))
                {
                    content.DepatcherTeam = code;
                }
            }

            txtDispatcherTeam.Text = content.DepatcherTeam;
        }

        private void cboActionTree_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = (TreeStartModel)cboActionTree.SelectedItem;
            content.ActionTreeId = result.TreeViewId;

            content.DepatcherTeam = _repo.GetWaitingTeamById(content.ActionTreeId, content.WaitForApproveTeamId).GetString();

            if (string.IsNullOrEmpty(content.DepatcherTeam))
            {
                var result1 = _repoReq.GetDefualtBuyer(reqHeadModel.RequestorID);
                content.DepatcherTeam = result1;
            }

            txtDispatcherTeam.Text = content.DepatcherTeam;
        }
    }
}