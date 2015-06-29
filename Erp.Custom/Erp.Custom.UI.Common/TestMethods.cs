using Erp.Custom.Core.Session;
using Erp.Custom.Core.Session.Models;
using Erp.Custom.Core.Session.Repositories;
using Erp.Custom.CostManagement;
using Erp.Custom.CostManagement.Models;
using Erp.Custom.SecurityAuth.Models;
using Erp.Custom.SecurityAuth.Repositories;
using Ice.CustomUI.PRList;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Erp.Custom.UI.Common
{
    public partial class TestMethods : baseInitialize
    {
        private readonly ISession _sess;
        private readonly Ice.CustomUI.PRList.IRequisition _pr;
        private readonly IAuth _repoAth;
        private readonly IRequisition _repoReq;
        private readonly IEstimate _repoEst;
        private ApprovalModel content;

        public TestMethods(CustomSession _session)
        {
            InitializeComponent();
            this._sess = new Session();
            this._pr = new Ice.CustomUI.PRList.RequisitionRepo();
            this._repoAth = new AuthRepo();
            this._repoReq = new RequisitionRepo();
            this._repoEst = new Erp.Custom.CostManagement.Repositories();
            epiSession = _session;
            content = new ApprovalModel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string seletedVal = comboBox1.SelectedItem.GetString();

            content.OrderNum = "54";
            content.ActionTreeId = 0;
            content.WaitForApproveTeamId = "PD-1";
            content.RequestorId = "manager";

            switch (seletedVal)
            {
                case "Test1":
                    string resultMsg;
                    var result = _repoEst.GetRowByID("P1E1506001", 0);
                    break;

                case "GetSessionModClient":
                    EndpointBindingSvc inst_ = new EndpointBindingSvc(epiSession);
                    inst_.GetSessionModClient(epiSession);
                    break;
            }
        }

        private void WriteOutput(string str)
        {
            textBox1.Clear();
            textBox1.Text = str;
        }

        private void ClearBinding()
        {
            comboBox2.DataBindings.Clear();
            textBox1.Clear();
        }

        private void BindingForm(ApprovalModel model)
        {
            ClearBinding();

            if (model.ActionTreeId == 0)
            {
                model.ActionTrees = _repoAth.GetStartTreeByUser(model.RequestorId).Where(x => x.TeamId.Equals(model.WaitForApproveTeamId)).ToList();
                comboBox2.Enabled = true;
            }
            else
            {
                model.ActionTrees = _repoAth.GetStartTreeByUser(model.RequestorId).ToList();
                var resutl = _repoAth.GetTreeByID(model.ActionTreeId);
                model.ActionTree = resutl.TreeViewName;
                comboBox2.Enabled = false;
            }

            if (model.ActionTrees.Count() != 0)
            {
                comboBox2.DataSource = model.ActionTrees;
                comboBox2.DisplayMember = "TreeViewName";
                comboBox2.ValueMember = "TreeViewId";
                comboBox2.DataBindings.Add("Text", model, "ActionTree");
            }
        }

        private void TestMethods_Load(object sender, EventArgs e)
        {
            ReqHeadModel reqHead = new ReqHeadModel();

            content.OrderNum = "128";
            content.ActionTreeId = 0;
            content.WaitForApproveTeamId = "PD";
            //model.DispatcherRemark = dgvList.CurrentRow.Cells["remark"].Value.ToString();

            reqHead = _pr.GetByID(Convert.ToInt32(content.OrderNum));

            content.RequestorId = epiSession.UserId;
            content.RequestorName = epiSession.Username;

            BindingForm(content);

            content.DepatcherTeam = string.IsNullOrEmpty(_repoAth.GetWaitingTeamById(content.ActionTreeId,
                                                            content.WaitForApproveTeamId)) ? "" : _repoAth.GetWaitingTeamById(content.ActionTreeId,
                                                            content.WaitForApproveTeamId);

            if (string.IsNullOrEmpty(content.DepatcherTeam))
            {
                var result = _repoReq.GetDefualtBuyer(content.RequestorId);
                content.DepatcherTeam = result;
            }
            textBox1.Text = content.DepatcherTeam;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            var result = (TreeStartModel)comboBox2.SelectedItem;

            textBox1.Text = result.TreeViewId.ToString();
        }
    }
}