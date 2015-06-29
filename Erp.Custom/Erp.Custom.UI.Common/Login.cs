using Erp.Custom.Core.Session.Models;
using Erp.Custom.Core.Session.Repositories;
using System;
using System.Windows.Forms;

namespace Erp.Custom.UI.Common
{
    public partial class Login : baseInitialize
    {
        private readonly ISession _repo;
        public CustomSession _session;
        //public Ice.Core.Session _session;

        public Login(CustomSession session = null)
        {
            InitializeComponent();
            this._session = session;
            this._repo = new Erp.Custom.Core.Session.Repositories.Session();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            epiSession = _session;
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUserName.Text = Properties.Settings.Default.username;
            txtPassword.Text = Properties.Settings.Default.password;
            chkRemember.Checked = Properties.Settings.Default.remember;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            string msgErr = string.Empty;

            //TODO switching offline/online 
            _session = _repo.IdentifySession(txtUserName.Text, txtPassword.Text, out msgErr);
            //_session = _repo.IdentifySession();
            eSession = _repo.GetSession();

            if (chkRemember.Checked)
            {
                Properties.Settings.Default.username = txtUserName.Text;
                Properties.Settings.Default.password = txtPassword.Text;
            }
            else
            {
                Properties.Settings.Default.username = "";
                Properties.Settings.Default.password = "";                
            }

            Properties.Settings.Default.remember = chkRemember.Checked;
            Properties.Settings.Default.Save();
            
            if (_session.SessionId != null)
            {
                epiSession = _session;
                this.Close();
            }
            else
            {
                MessageBox.Show(msgErr, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}