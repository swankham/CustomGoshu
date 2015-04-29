using Erp.Custom.Session.Models;
using Erp.Custom.Session.Repositories;
using Erp.Custom.Framework;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using System;

namespace Erp.Custom.UI.Common
{
    public class baseInitialize : Form
    {
        #region Fields

        private readonly ISession _repo;
        public CustomSession epiSession;

        #endregion Fields

        #region Consturctors

        public baseInitialize()
        {
            if (Thread.CurrentThread.CurrentCulture.Name == "th-TH")
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            }

            this._repo = new Erp.Custom.Session.Repositories.Session();
            this.epiSession = new CustomSession();

            Program.UseTheme(this);
        }

        public void ShowForm(string FormName)
        {
            try
            {
                Assembly asm = Assembly.GetEntryAssembly();
                string path = "Erp.Custom.UI.Common.Views";
                string formname = path + "." + FormName;
                Type formtype = asm.GetType(formname);
                Form f = (Form)Activator.CreateInstance(formtype, new object[] { epiSession, null }) as Form;
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form path not valid.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion Consturctors
    }
}