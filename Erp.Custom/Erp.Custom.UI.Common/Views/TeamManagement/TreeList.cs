using Erp.Custom.Core.Session.Models;
using Erp.Custom.SecurityAuth.Models;
using Erp.Custom.SecurityAuth.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erp.Custom.UI.Common.Views.TeamManagement
{
    public partial class TreeList : baseInitialize
    {
        private readonly IAuth _repo;
        private IList<TreeViewModel> trees;
        public TreeViewModel selected;

        public TreeList(CustomSession _session = null, TransModel param = null)
        {
            InitializeComponent();
            this._repo = new AuthRepo();
            this.trees = new List<TreeViewModel>();
            this.selected = new TreeViewModel(); 
            epiSession = _session;
            DefaultSession();
        }

        private void SetGrid(IList<TreeViewModel> list)
        {
            dgvList.Rows.Clear();
            foreach (var item in list)
            {
                dgvList.Rows.Add(item.TreeViewName, item.Description, Convert.ToBoolean(item.VisibleFlag));
            }
        }

        private void TreeList_Load(object sender, EventArgs e)
        {
            trees = _repo.GetAllTree().Where(x => x.VisibleFlag.Equals(1)).ToList();
            SetGrid(trees);
        }

        private void SetInvoiceByBillSelected()
        {
            string treeName = dgvList.CurrentRow.Cells["id"].Value.ToString();
            selected = _repo.GetTree(treeName);
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SetInvoiceByBillSelected();
            this.Close();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
