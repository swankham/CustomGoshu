using Ice.Lib.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ice.CustomUI.PRList
{
    public partial class BuyerSearch : EpiBaseForm
    {
        private Ice.Core.Session epiSession;
        private readonly IRequisition _repo;
        public string Code;
        public string UserID;

        public BuyerSearch(Ice.Core.Session _session = null, string userId = null)
        {
            InitializeComponent();
            epiSession = _session;
            this.Code = string.Empty;
            this.UserID = userId;
            this._repo = new RequisitionRepo();
        }

        private void BuyerSearch_Load(object sender, EventArgs e)
        {
            cboFilter.SelectedIndex = 0;
            txtFilter.Clear();
            var result = _repo.GetAllBuyer(epiSession.CompanyID, UserID).OrderBy(x => x.BuyerCode).ToList();
            SetGrid(result);
        }

        private void SetGrid(List<BuyerModel> list)
        {
            dgvList.Rows.Clear();
            foreach (var item in list)
            {
                dgvList.Rows.Add(item.BuyerCode, item.BuyerName);
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            BuyerModel model = new BuyerModel();
            if (cboFilter.SelectedIndex == 0)
            {
                model.BuyerCode = txtFilter.Text;
            }
            else if (cboFilter.SelectedIndex == 1)
            {
                model.BuyerName = txtFilter.Text;
            }

            var result = _repo.BuyerByFilter(epiSession.CompanyID, UserID, model).OrderBy(x => x.BuyerCode).ToList();
            SetGrid(result);
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            GetRowSelected();
            this.Close();
        }

        private void GetRowSelected()
        {
            this.Code = dgvList.CurrentRow.Cells["buyercode1"].Value.ToString().Trim();
            
        }
    }
}
