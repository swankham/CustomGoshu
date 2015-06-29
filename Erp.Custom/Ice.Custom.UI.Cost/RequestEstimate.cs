using Erp.Custom.Core.Session.Models;
using Erp.Custom.CostManagement;
using Erp.Custom.CostManagement.Models;
using Erp.Custom.SecurityAuth.Repositories;
using Ice.Lib.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace Ice.Custom.UI.CostRequest
{
    public partial class RequestEstimate : EpiBaseForm
    {
        private Ice.Core.Session epiSession;
        private Transaction trans;
        private CostRequestModel model;
        private readonly IAuth _repoAth;

        private readonly IEstimate _repo;

        public RequestEstimate(EpiTransaction iTrans)
            : base(iTrans)
        {
            InitializeComponent();
            this.trans = (Transaction)iTrans;
            this.epiSession = ((Ice.Core.Session)oTransaction.Session);

            this._repo = new Erp.Custom.CostManagement.Repositories();
            this._repoAth = new AuthRepo();
            this.model = new CostRequestModel();
        }

        private void BindData(CostRequestModel result)
        {
            ClearBinding();

            #region Initail list of value

            txtEstimateNo.DataBindings.Add("Text", result, "EstimateNo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtReviseNo.DataBindings.Add("Text", result, "RevisionStr", true, DataSourceUpdateMode.OnPropertyChanged);
            txtRequestBy.DataBindings.Add("Text", result, "RequestBy", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpRequestDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", result, "RequestDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            chkGKCStadardFlag.DataBindings.Add("Checked", result, "GKCStadardFlag", true, DataSourceUpdateMode.OnPropertyChanged);
            chkCustomerSpecFlag.DataBindings.Add("Checked", result, "CustomerSpecFlag", true, DataSourceUpdateMode.OnValidation);
            chkJisFlag.DataBindings.Add("Checked", result, "JisFlag", true, DataSourceUpdateMode.OnPropertyChanged);
            chkDinFlag.DataBindings.Add("Checked", result, "DinFlag", true, DataSourceUpdateMode.OnPropertyChanged);
            chkANSFlag.DataBindings.Add("Checked", result, "ANSFlag", true, DataSourceUpdateMode.OnPropertyChanged);
            chkOtherFlag.DataBindings.Add("Checked", result, "OtherFlag", true, DataSourceUpdateMode.OnPropertyChanged);
            txtOtherRemark.DataBindings.Add("Text", result, "OtherRemark", true, DataSourceUpdateMode.OnPropertyChanged);
            txtCustomer.DataBindings.Add("Text", result, "CustomerName", true, DataSourceUpdateMode.OnPropertyChanged);
            txtProjectName.DataBindings.Add("Text", result, "ProjectName", true, DataSourceUpdateMode.OnPropertyChanged);
            txtBudget.DataBindings.Add("Text", result, "Budget", true, DataSourceUpdateMode.OnPropertyChanged, 1, "#,###,##0.00");
            txtLocation.DataBindings.Add("Text", result, "Location", true, DataSourceUpdateMode.OnPropertyChanged);
            txtRemarks.DataBindings.Add("Text", result, "Remarks", true, DataSourceUpdateMode.OnPropertyChanged);

            txtFlowsheetFilePath.DataBindings.Add("Text", result, "FlowsheetFilePath", true, DataSourceUpdateMode.OnPropertyChanged);
            txtLayoutFilePath.DataBindings.Add("Text", result, "LayoutFilePath", true, DataSourceUpdateMode.OnPropertyChanged);
            txtSpecFilePath.DataBindings.Add("Text", result, "SpecFilePath", true, DataSourceUpdateMode.OnPropertyChanged);
            txtOtherFilePath.DataBindings.Add("Text", result, "OtherFilePath", true, DataSourceUpdateMode.OnPropertyChanged);


            rdoEstimateByCost.Checked = result.EstimateByCostFlag;
            rdoEstimateByOwner.Checked = !result.EstimateByCostFlag;
            #endregion Initail list of value
        }

        private void ClearBinding()
        {
            txtEstimateNo.DataBindings.Clear();
            txtReviseNo.DataBindings.Clear();
            rdoEstimateByCost.Checked = true;
            rdoEstimateByOwner.Checked = false;
            txtRequestBy.DataBindings.Clear();
            dtpRequestDate.DataBindings.Clear();
            chkGKCStadardFlag.DataBindings.Clear();
            chkCustomerSpecFlag.DataBindings.Clear();
            chkJisFlag.DataBindings.Clear();
            chkDinFlag.DataBindings.Clear();
            chkANSFlag.DataBindings.Clear();
            chkOtherFlag.DataBindings.Clear();
            txtOtherRemark.DataBindings.Clear();

            txtProjectName.DataBindings.Clear();
            txtBudget.DataBindings.Clear();
            txtLocation.DataBindings.Clear();
            txtCustomer.DataBindings.Clear();
            txtRemarks.DataBindings.Clear();

            txtFlowsheetFilePath.DataBindings.Clear();
            txtLayoutFilePath.DataBindings.Clear();
            txtSpecFilePath.DataBindings.Clear();
            txtOtherFilePath.DataBindings.Clear();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.model.RequestBy = epiSession.UserID;
            this.model.RequestDate = DateTime.Now;

            using (EstimateReqDialog frm = new EstimateReqDialog(epiSession))
            {
                frm.ShowDialog();
                if (frm.selected != null)
                {
                    this.model = frm.selected;
                }
            }
            BindData(model);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Save(string.IsNullOrEmpty(this.model.EstimateNo));
        }

        private void Save(bool insertFlag)
        {
            string resultMsg = string.Empty;

            model.EstimateByCostFlag = (rdoEstimateByCost.Checked) ? true : false;
            model.RevisionStr = txtReviseNo.Text.Trim();
            model.GKCStadardFlag = chkGKCStadardFlag.Checked;
            model.JisFlag = chkJisFlag.Checked;
            model.ANSFlag = chkANSFlag.Checked;
            model.CustomerSpecFlag = chkCustomerSpecFlag.Checked;
            model.DinFlag = chkDinFlag.Checked;
            model.OtherFlag = chkOtherFlag.Checked;

            model.RequestDate = dtpRequestDate.Value;
            model.OtherRemark = txtOtherRemark.Text;
            model.ProjectName = txtProjectName.Text;
            model.Budget = Convert.ToDecimal(txtBudget.Text);
            model.Location = txtLocation.Text;
            model.Remarks = txtRemarks.Text;
            model.CustomerName = txtCustomer.Text;

            ValidationContext context = new ValidationContext(this.model, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(this.model, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                    MessageBox.Show(result.ErrorMessage, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CustomSession sess = new CustomSession();
                sess.UserId = epiSession.UserID;
                model.TeamId = _repoAth.GetTeamByUserID(epiSession.UserID);
                var result = _repo.Save(sess, model, insertFlag, out resultMsg);
                
                BindData(result);
                MessageBox.Show(resultMsg);
            }
        }

        private void RequestEstimate_Load(object sender, EventArgs e)
        {
            model.RequestDate = DateTime.Now;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.model = new CostRequestModel();
            this.model.RequestDate = DateTime.Now;
            this.model.RequestBy = epiSession.UserID;
            this.model.EstimateByCostFlag = true;
            BindData(this.model);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            BindData(this.model);
        }

        private void mnuClear_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            BindData(this.model);
        }

        private void mnuNewEstimate_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            toolStripButton2_Click(sender, e);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Save(true);
        }
    }
}