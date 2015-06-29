using Erp.Custom.Core.Session.Models;
using Erp.Custom.SecurityAuth.Models;
using Erp.Custom.SecurityAuth.Repositories;
using Ice.Lib.Framework;
using System;
using System.Windows.Forms;

namespace Ice.Custom.UI.Auth
{
    public partial class AddTree : EpiBaseForm
    {
        private readonly IAuth _repo;
        public TreeViewModel addedModel;
        Ice.Core.Session epiSession;

        public AddTree(Ice.Core.Session _session, string param = null)
        {
            InitializeComponent();
            this._repo = new AuthRepo();
            this.epiSession = _session;
            addedModel = new TreeViewModel();
        }

        private void AddTree_Load(object sender, EventArgs e)
        {
            ClearBinding();
        }

        private void ClearBinding()
        {
            txtName.Text = "";
            txtDesc.Text = "";
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtDesc.Text))
            {
                MessageBox.Show("Please fill data to valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (_repo.CheckExistTree(txtName.Text.Trim()))
                {
                    MessageBox.Show("The value has duplicate. Please change to another name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    TreeViewModel model = new TreeViewModel();
                    model.TreeViewName = txtName.Text;
                    model.Description = txtDesc.Text;
                    addedModel = _repo.SaveTree(epiSession, model);
                    this.Close();
                }
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            addedModel = null;
            this.Close();
        }
    }
}