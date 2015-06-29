using Erp.Custom.Core.Session.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erp.Custom.UI.Common.Views.CostManagement
{
    public partial class CostRequest : baseInitialize
    {
        public CostRequest(CustomSession _session = null, string param = null)
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mnuDuplicate_Click(object sender, EventArgs e)
        {
            RequesitionCopy frm = new RequesitionCopy(epiSession);
            frm.ShowDialog();            
        }

        private void mnuReviseEstimate_Click(object sender, EventArgs e)
        {
            ReviseReason frm = new ReviseReason(epiSession);
            frm.ShowDialog();  
        }

    }
}
