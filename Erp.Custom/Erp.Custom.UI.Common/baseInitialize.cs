using Erp.Custom.Core.Session.Models;
using Erp.Custom.Core.Session.Repositories;
using Erp.Custom.Core.Framework;
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
        public static CustomSession epiSession;
        public static Ice.Core.Session eSession;

        #endregion Fields

        #region Consturctors

        public baseInitialize()
        {
            if (Thread.CurrentThread.CurrentCulture.Name == "th-TH")
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            }

            this._repo = new Erp.Custom.Core.Session.Repositories.Session();
            //this.epiSession = new CustomSession();
            
            Program.UseTheme(this);
        }


        public void DefaultSession()
        {
            eSession = _repo.GetSession();
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

        public void ShowForm(ListViewItem lvItem)
        {
            try
            {
                Assembly asm = Assembly.GetEntryAssembly();
                string path = "Erp.Custom.UI.Common.Views";
                string formname = path + "." + lvItem.Name;
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