using Erp.Custom.CostManagement;
using Erp.Custom.CostManagement.Models;
using Erp.Custom.SecurityAuth.Repositories;
using Ice.Lib.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ice.Custom.UI.CostRequest
{
    public partial class EstimateReqDialog : EpiBaseForm
    {
        private Ice.Core.Session epiSession;
        private readonly IEstimate _repo;
        private readonly IAuth _repoAuth;
        private IList<CostRequestModel> estimateList;
        public CostRequestModel selected;

        public EstimateReqDialog(Ice.Core.Session _session = null)
        {
            InitializeComponent();
            epiSession = _session;
            this._repo = new Erp.Custom.CostManagement.Repositories();
            this._repoAuth = new AuthRepo();
            this.estimateList = new List<CostRequestModel>();
            this.selected = new CostRequestModel();
        }

        private void SetGrid(List<CostRequestModel> list)
        {
            dgvList.Rows.Clear();
            foreach (var item in list)
            {
                dgvList.Rows.Add(item.EstimateNo, item.ReviseNo, item.RevisionStr, item.RequestDate, item.RequestBy, item.Ref_ProjectID, item.ProjectName);
            }
        }

        private void EstimateReqDialog_Load(object sender, EventArgs e)
        {
            string team = _repoAuth.GetTeamByUserID(epiSession.UserID);
            estimateList = _repo.GetEstimateAll(team).ToList();
            SetGrid(estimateList.ToList());
            cboFilter.SelectedIndex = 0;
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            if (cboFilter.SelectedIndex.Equals(0))
            {
                SetGrid(estimateList.Where(x => x.EstimateNo.Contains(txtFilter.Text.Trim())).ToList());
            }
            else if (cboFilter.SelectedIndex.Equals(1))
            {
                SetGrid(estimateList.Where(x => x.RequestBy.Contains(txtFilter.Text.Trim())).ToList());
            }
            else if (cboFilter.SelectedIndex.Equals(2))
            {
                SetGrid(estimateList.Where(x => x.Ref_ProjectID.Contains(txtFilter.Text.Trim())).ToList());
            }
            else if (cboFilter.SelectedIndex.Equals(3))
            {
                SetGrid(estimateList.Where(x => x.ProjectName.Contains(txtFilter.Text.Trim())).ToList());
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            butSearch_Click(sender, e);
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SetSelected();
            this.Close();
        }

        private void SetSelected()
        {
            string estNo = dgvList.CurrentRow.Cells["estimateno"].Value.ToString().Trim();
            string rev = dgvList.CurrentRow.Cells["rev"].Value.ToString().Trim();
            selected = _repo.GetEstimateByID(estNo, rev);
        }

        private void butSelect_Click(object sender, EventArgs e)
        {
            SetSelected();
            this.Close();
        }
    }
}