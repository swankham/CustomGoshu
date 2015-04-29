using Erp.Custom.Session.Models;
using Erp.Custom.Session.Repositories;
using Erp.Custom.Framework;
using System.Threading;
using System.Windows.Forms;

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

        #endregion Consturctors
    }
}