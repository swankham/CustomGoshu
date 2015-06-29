using Erp.Custom.Core.Session.Models;
using Erp.Custom.SecurityAuth.Models;
using Erp.Custom.SecurityAuth.Repositories;
using System;
using System.Windows.Forms;

namespace Erp.Custom.UI.Common.Views.TeamManagement
{
    public partial class AddTree : baseInitialize
    {
        private readonly IAuth _repo;
        public TreeViewModel addedModel;

        public AddTree(CustomSession _session = null, string param = null)
        {
            InitializeComponent();
            this._repo = new AuthRepo();
            epiSession = _session;
            addedModel = new TreeViewModel();
            DefaultSession();
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
                    addedModel = _repo.SaveTree(eSession, model);
                    this.Close();
                }
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}